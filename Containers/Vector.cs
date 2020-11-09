using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VPaint.Controllers;

namespace VPaint
{
    public class Vector
    {

        public Guid Id = Guid.Empty;
        public VectorPoint Start = new VectorPoint();
        public VectorPoint End = new VectorPoint();
        public bool Sparkle = false;
        public int Page = 0;
        //public bool Selected = false;
        public string SourceComment = "";

        private int _brightness = 16;

        [XmlIgnore]
        public Color Color = Color.White;

        public Vector() { }

        public Vector(Point start, Point end)
        {
            Id = Guid.NewGuid();
            Start = VectorPointController.Create(start);
            End = VectorPointController.Create(end);
            Color = Color.Transparent;
        }

        public Vector(Point start, Point end, Color color)
        {
            Id = Guid.NewGuid();
            Start = VectorPointController.Create(start);
            End = VectorPointController.Create(end);
            Color = color;
        }

        public override string ToString()
        {
            return "[" + Start.Point.X.ToString() + "," + Start.Point.Y.ToString() + "][" + End.Point.X.ToString() + "," + End.Point.Y.ToString() + "]";
        }

        public string ToString(Point centerPoint)
        {
            return "[" + (Start.Point.X-centerPoint.X).ToString() + "," + (Start.Point.Y-centerPoint.Y).ToString() + "][" + (End.Point.X-centerPoint.X).ToString() + "," + (End.Point.Y-centerPoint.Y).ToString() + "]";
        }


        [XmlElement]
        public string ColorCode
        {
            get { return ColorTranslator.ToHtml(Color); }
            set { Color = ColorTranslator.FromHtml(value); }
        }

        public int Brightness
        {
            get
            {
                return _brightness;
            }
            set
            {
                _brightness = value;
                if (_brightness > 16) _brightness = 16;
            }
        }


        public Vector Clone()
        {
            Vector newVector = new Vector();
            newVector.Start.Point = this.Start.Point;
            newVector.End.Point = this.End.Point;
            newVector.Brightness = this.Brightness;
            newVector.Color = this.Color;
            newVector.ColorCode = this.ColorCode;
            newVector.Id = new Guid();
            newVector.Page = this.Page;
            //newVector.Selected = false;
            newVector.SourceComment = "Generated from scissor";
            newVector.Sparkle = this.Sparkle;
            return newVector;
        }
    }
}
