using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VPaint
{
    public class Drawing
    {
        private readonly ObservableCollection<Vector> _vectors = new ObservableCollection<Vector>();
        private VectorCommandController _commandController = null;
        [XmlIgnore]
        public VectorCollectionChanged OnVectorCollectionChanged = null;

        public bool IsDirty { get; set; }
        public string FileName { get; set; }
        public Point CenterPoint { get; set; }

        public Size Extents
        {
            get
            {
                int xMin = 0;
                int xMax = 0;
                int yMin = 0;
                int yMax = 0;

                foreach (Vector v in _vectors)
                {
                    if (v.Start.Point.X < xMin) xMin = v.Start.Point.X;
                    if (v.Start.Point.Y < yMin) yMin = v.Start.Point.Y;
                    if (v.Start.Point.X > xMax) xMax = v.Start.Point.X;
                    if (v.Start.Point.Y > yMax) yMax = v.Start.Point.Y;

                    if (v.End.Point.X < xMin) xMin = v.End.Point.X;
                    if (v.End.Point.Y < yMin) yMin = v.End.Point.Y;
                    if (v.End.Point.X > xMax) xMax = v.End.Point.X;
                    if (v.End.Point.Y > yMax) yMax = v.End.Point.Y;
                }

                return new Size(xMax - xMin, yMax - yMin);
            }
        }

        public bool ShowCenterPoint { get; set; }

        public Drawing()
        {
            _vectors.CollectionChanged += vectors_CollectionChanged;
            _commandController = new VectorCommandController(this);
            CenterPoint = new Point(Extents.Width / 2, Extents.Height / 2);
        }

        public Drawing(string fileName)
        {
            FileName = fileName;
            _vectors.CollectionChanged += vectors_CollectionChanged;
            _commandController = new VectorCommandController(this);
            CenterPoint = new Point(Extents.Width / 2, Extents.Height / 2);
        }

        private void vectors_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            IsDirty = true;
            if (OnVectorCollectionChanged!= null)
            {
                OnVectorCollectionChanged();
            }
        }

        public string GetFilename()
        {
            return FileName + (IsDirty ? "*" : "");
        }


        public ObservableCollection<Vector> Vectors { get { return _vectors; } }

        public void ClearAllSelections()
        {
            foreach (Vector v in _vectors)
            {
                v.Start.Selected = false;
                v.End.Selected = false;
            }
        }

        public List<VectorPoint> GetSelectedPoints()
        {
            List<VectorPoint> selectedPoints = new List<VectorPoint>();
            foreach(Vector v in _vectors)
            {
                if (v.Start.Selected)
                {
                    if (selectedPoints.Where(p => p.Point.Matches(v.Start.Point)).Count() == 0)
                    {
                        selectedPoints.Add(v.Start);
                    }
                }
                if (v.End.Selected)
                {
                    if (selectedPoints.Where(p => p.Point.Matches(v.End.Point)).Count() == 0)
                    {
                        selectedPoints.Add(v.End);
                    }
                }
            }
            return selectedPoints;
        }

        public string GetSVG()
        {
            StringBuilder svg = new StringBuilder();
            svg.AppendLine("<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"" + Extents.Width.ToString() + "px\" height=\"" + Extents.Height.ToString() + "\" viewBox=\"0 0 " + Extents.Width.ToString() + " " + Extents.Height.ToString() + "\" preserveAspectRatio=\"xMidYMid meet\" >");

            List<Point> points = new List<Point>();
            points.Add(CenterPoint);
            foreach(Vector vector in _vectors)
            {
                points.Add(points[points.Count-1].Add(vector.End.Point).Subtract(vector.Start.Point));
            }

            
            svg.AppendLine("<polyline style=\"stroke: black; fill: none; stroke - width:1px;\" id=\"e1_polyline\" points=\""+ GetPointString(points) + "\"/>");
            svg.AppendLine("</svg>");
            return svg.ToString();

        }

        private string GetPointString(List<Point> points)
        {
            List<string> coords = new List<string>();
            foreach(Point p in points)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(p.X.ToString());
                sb.Append(" ");
                sb.Append(p.Y.ToString());
                coords.Add(sb.ToString());
            }
            return String.Join(" ", coords.ToArray());
        }
    }
}
