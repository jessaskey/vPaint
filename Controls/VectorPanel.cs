﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using VPaint.Controls;
using System.Web.UI.WebControls.WebParts;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace VPaint
{
    public enum ToolAction
    {
        None,
        Selecting,
        Defining,
        Moving
    }

    public partial class VectorPanel : UserControl
    {
        private bool _showGrid = true;
        private Brush _gridBrush = Brushes.White;
        private Brush _boundsBrush = Brushes.Gray;
        //private Pen _editPen = new Pen(Brushes.Yellow, 1);
        private Pen _majorAxisPen = new Pen(Brushes.DimGray, 1);
        private int _editDotSize = 4;
        private int _gridSize = 10;
        private int _gridDotSize = 1;
        //private Point _lastMouseSnap = Point.Empty;
        //private float _zoom = 1f;
        private int _vectorWidth = 1;
        private bool _showHiddenVectors = false;

        private Drawing _drawing = null;
        private string _currentDrawingPath = "";

        //private Guid _selectedVector = Guid.Empty;
        //private List<Point> _selectedPoints = new List<Point>();
        //private List<Guid> _selectedVectors = new List<Guid>();
        //private Point _dragStart = Point.Empty;

        public VectorPanel(Drawing drawing)
        {
            InitializeComponent();
            scaledPictureBox.Parent = panel;
            scaledPictureBox.ResizePictureBox();
            BackColor = Color.Black;
            _drawing = drawing;
            _vectorWidth = Globals.vectorWidth;
            //_toolController = new VectorToolController(this);

            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(panel, true, null);

        }

        public ReportCoordinatesDelegate OnReportCoordinates = null;
        public UpdateCursorDelegate OnUpdateCursor = null;
        public UpdateStatusDelegate OnUpdateStatus = null;

        public bool ShowHiddenVectors
        {
            get { return _showHiddenVectors; }
            set { _showHiddenVectors = value; }
        }

        public bool ShowGrid
        {
            get { return _showGrid; }
            set { _showGrid = value; }
        }

        public Drawing GetDrawing()
        {
            return _drawing;
        }

        public string DrawingPath
        {
            get
            {
                return _currentDrawingPath;
            }
            set
            {
                _currentDrawingPath = value;
            }
        }

        public void ClearAllSelections()
        {
            _drawing.ClearAllSelections();
        }

        public void AddSelectedPoint(Point point)
        {
            //Point centerPoint = new Point(scaledPictureBox.Width / 2, scaledPictureBox.Height / 2);
            foreach(var v in _drawing.Vectors)
            {
                if (v.Start.Point.Matches(point))
                {
                    v.Start.Selected = true;
                }
                if (v.End.Point.Matches(point))
                {
                    v.End.Selected = true;
                }
            }
            UpdateSelectedStatus();
        }

        public bool RemoveSelectedPoint(Point point)
        {
            bool removed = false;
            //Point centerPoint = new Point(scaledPictureBox.Width / 2, scaledPictureBox.Height / 2);
            foreach (Vector v in _drawing.Vectors.Where(p => p.Start.Point.Matches(point)))
            {
                v.Start.Selected = false;
                removed = true;
            }
            foreach (Vector v in _drawing.Vectors.Where(p => p.End.Point.Matches(point)))
            {
                v.End.Selected = false;
                removed = true;
            }
            return removed;
        }

        public void UpdateSelectedStatus()
        {
            List<Point> selectedDrawingPoints = _drawing.GetSelectedPoints();
            UpdateStatus("Selected Point(s) " + String.Join(",", selectedDrawingPoints.Select(p => "[" + p.ToString() + "]").ToArray()));
        }

        private void DrawDot(Point p, Graphics g)
        {
            g.FillRectangle(Brushes.White, p.X - (_editDotSize / 2), p.Y - (_editDotSize / 2), _editDotSize, _editDotSize);
        }

        private void DrawDot(Point p, Graphics g, Brush brush, int size)
        {
            g.FillRectangle(brush, p.X - (size / 2), p.Y - (size / 2), size, size);
        }

        public void RedrawControl()
        {
            panel.Invalidate();
            scaledPictureBox.Invalidate();
            Parent.Parent.Invalidate();
        }


        //private Point GetSnapPoint(PointF p)
        //{
        //    PointF scaledPoint = scaledPictureBox.ScalePoint(p);
        //    //now snap it
        //    return new Point((int)(scaledPoint.X / Globals.snapGrid) * Globals.snapGrid, (int)(scaledPoint.Y / Globals.snapGrid) * Globals.snapGrid);
        //}

        //private PointF ScalePointToZoom(PointF p)
        //{
        //    scaledPictureBox.ScalePoint(p);
        //    p.X = (int)(((float)p.X) / _zoom);
        //    p.Y = (int)(((float)p.Y) / _zoom);
        //    return p;
        //}

        public void UpdateStatus(string s)
        {
            if (OnUpdateStatus != null)
            {
                OnUpdateStatus(s);
            }
        }

        public Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
        }

        //public VectorPoint? FindVectorPoint(Point hitPoint)
        //{
        //    int tolerance = (int)(Globals.snapGrid*scaledPictureBox.Zoom);
        //    Point centerPoint = new Point(scaledPictureBox.Width / 2, scaledPictureBox.Height / 2);
        //    Point adjustedHitPoint = hitPoint.Subtract(centerPoint).Divide(scaledPictureBox.Zoom);
        //    foreach (Vector v in _drawing.Vectors)
        //    {
        //        if (v.Start.Point.IsWithinCircle(adjustedHitPoint, tolerance/2))
        //        {
        //            return v.Start;
        //        }
        //        else
        //        {
        //            if (v.End.Point.IsWithinCircle(adjustedHitPoint, tolerance/2))
        //            {
        //                return v.End;
        //            }
        //        }
        //    }
        //    return null;
        //}

        //public Vector FindVector(Point hitPoint)
        //{
        //    int tolerance = (int)(Globals.snapGrid * scaledPictureBox.Zoom);
        //    Pen hitPen = new Pen(Color.Black, tolerance);
        //    Point centerPoint = new Point(scaledPictureBox.Width / 2, scaledPictureBox.Height / 2);
        //    Point adjustedHitPoint = hitPoint.Subtract(centerPoint).Divide(scaledPictureBox.Zoom);

        //    var line = _drawing.Vectors.Where(v =>
        //    {
        //        Point p1 = new Point(Math.Min(v.Start.Point.X, v.End.Point.X), Math.Min(v.Start.Point.Y, v.End.Point.Y));
        //        Point p2 = new Point(Math.Max(v.Start.Point.X, v.End.Point.X), Math.Max(v.Start.Point.Y, v.End.Point.Y));
        //        return adjustedHitPoint.X >= (p1.X - tolerance) && adjustedHitPoint.X <= (p2.X + tolerance) && adjustedHitPoint.Y >= (p1.Y - tolerance) && adjustedHitPoint.Y <= (p2.Y + tolerance);
        //    }).FirstOrDefault(v =>
        //    {
        //        using (GraphicsPath gp = new GraphicsPath())
        //        {
        //            gp.AddLine(v.Start.Point, v.End.Point);
        //            return gp.IsOutlineVisible(adjustedHitPoint, hitPen);
        //        }
        //    });
        //    return line;
        //}

        /// <summary>
        /// Does all the hit testing for the vector panel, both Vector and VectorPoints
        /// </summary>
        /// <param name="hitPoint">The raw scaledPictureBox coordinates to hit test for. This point will be adjusted to take care of zoom and position of the current pictureBox. </param>
        /// <param name="selectedOnly">Set to true if you only want to test currently selected items.</param>
        /// <param name="selectOnHit">If set to true, then the hit points will be set to selected and non-hit points will be set to false. If false, the selected properties will not be changed on any point.</param>
        /// <returns></returns>
        public List<VectorPoint> HitTest(Point hitPoint, bool selectedOnly, bool selectOnHit)
        {
            int tolerance = (int)((Globals.snapGrid * scaledPictureBox.Zoom)/2);
            Pen hitPen = new Pen(Color.Black, tolerance);
            Point centerPoint = new Point(scaledPictureBox.Width / 2, scaledPictureBox.Height / 2);
            Point adjustedHitPoint = hitPoint.Subtract(centerPoint).Divide(scaledPictureBox.Zoom);

            List<VectorPoint> hitVectorPoints = new List<VectorPoint>();
            foreach (Vector v in _drawing.Vectors)
            {
                //test points first...
                if ((v.Start.Selected && selectedOnly) || !selectedOnly)
                {
                    if (v.Start.Point.IsWithinCircle(adjustedHitPoint, tolerance / 2))
                    {
                        hitVectorPoints.Add(v.Start);
                        if (selectOnHit)
                        {
                            v.Start.Selected = true;
                        }
                    }
                }
                if ((v.End.Selected && selectedOnly) || !selectedOnly)
                {
                    if (v.End.Point.IsWithinCircle(adjustedHitPoint, tolerance / 2))
                    {
                        hitVectorPoints.Add(v.End);
                        if (selectOnHit)
                        {
                            v.End.Selected = true;
                        }
                    }
                }
            }
            if (hitVectorPoints.Count == 0) {
                foreach (Vector v in _drawing.Vectors)
                {
                    if ((v.Start.Selected && v.End.Selected && selectedOnly) || !selectedOnly)
                    {
                        //test this vector line for a hit
                        Point p1 = new Point(Math.Min(v.Start.Point.X, v.End.Point.X), Math.Min(v.Start.Point.Y, v.End.Point.Y));
                        Point p2 = new Point(Math.Max(v.Start.Point.X, v.End.Point.X), Math.Max(v.Start.Point.Y, v.End.Point.Y));
                        bool vectorHit = adjustedHitPoint.X >= (p1.X - tolerance)
                                            && adjustedHitPoint.X <= (p2.X + tolerance)
                                            && adjustedHitPoint.Y >= (p1.Y - tolerance)
                                            && adjustedHitPoint.Y <= (p2.Y + tolerance);

                        bool graphicsHit = false;
                        if (vectorHit)
                        {
                            using (GraphicsPath gp = new GraphicsPath())
                            {
                                gp.AddLine(v.Start.Point, v.End.Point);
                                if (gp.IsOutlineVisible(adjustedHitPoint, hitPen))
                                {
                                    graphicsHit = true;
                                    //hit, add our points to the hit list
                                    hitVectorPoints.Add(v.Start);
                                    hitVectorPoints.Add(v.End);
                                    if (selectOnHit)
                                    {
                                        //select both start and end
                                        v.Start.Selected = true;
                                        v.End.Selected = true;
                                    }
                                    //find any other vectors that have these points as well..
                                    foreach (Vector otherVector in _drawing.Vectors.Where(ov => ov.Id != v.Id))
                                    {
                                        if (v.Start.Point.Matches(otherVector.Start.Point))
                                        {
                                            hitVectorPoints.Add(otherVector.Start);
                                            if (selectOnHit)
                                            {
                                                otherVector.Start.Selected = true; ;
                                            }
                                        }
                                        if (v.Start.Point.Matches(otherVector.End.Point))
                                        {
                                            hitVectorPoints.Add(otherVector.End);
                                            if (selectOnHit)
                                            {
                                                otherVector.End.Selected = true; ;
                                            }
                                        }
                                        if (v.End.Point.Matches(otherVector.Start.Point))
                                        {
                                            hitVectorPoints.Add(otherVector.Start);
                                            if (selectOnHit)
                                            {
                                                otherVector.Start.Selected = true;
                                            }
                                        }
                                        if (v.End.Point.Matches(otherVector.End.Point))
                                        {
                                            hitVectorPoints.Add(otherVector.End);
                                            if (selectOnHit)
                                            {
                                                otherVector.End.Selected = true; ;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //if (vectorHit && graphicsHit)
                        //{
                        //    //test points individually here
                        //    if (v.Start.Point.IsWithinCircle(adjustedHitPoint, tolerance / 2))
                        //    {
                        //        hitVectorPoints.Add(v.Start);
                        //        if (selectOnHit)
                        //        {
                        //            v.Start.Selected = true;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        //for now, assume that if start is hit, then end cant be hit. This might
                        //        //cause an issue down the road if the vector is shorter than the tolerance
                        //        //but for now, lets leave it.
                        //        if (v.End.Point.IsWithinCircle(adjustedHitPoint, tolerance / 2))
                        //        {
                        //            hitVectorPoints.Add(v.End);
                        //            if (selectOnHit)
                        //            {
                        //                v.End.Selected = true;
                        //            }
                        //        }
                        //    }
                        //}
                    }
                }
            }
            return hitVectorPoints;
        }

        public void Delete()
        {

            List<Vector> selectedVectors = _drawing.Vectors.Where(v => v.Start.Selected && v.Start.Selected).ToList();
            if (selectedVectors.Count > 0)
            {
                foreach (Vector v in selectedVectors)
                {
                    _drawing.Vectors.Remove(v);

                }
                RedrawControl();
            }
        }

        public void CreateVector(Point start, Point end, Color color)
        {
            Point centerPoint = new Point(panel.Width / 2, panel.Height / 2);
            Point adjustedStart = start.Subtract(centerPoint).Divide(scaledPictureBox.Zoom);
            Point adjustedEnd = end.Subtract(centerPoint).Divide(scaledPictureBox.Zoom);
            Vector vector = new Vector(adjustedStart, adjustedEnd, color);
            _drawing.Vectors.Add(vector);
        }

        public new void KeyDown(object sender, KeyEventArgs e)
        {
            //does the vector panel want any keys?
            if (e.KeyCode == Keys.Delete)
            {
                Delete();
            }
            else if (e.KeyCode == Keys.Up)
            {
                MoveSelectedPoints(Globals.snapGrid, 0, 0, 0);
            }
            else if (e.KeyCode == Keys.Down)
            {
                MoveSelectedPoints(0, Globals.snapGrid, 0, 0);
            }
            else if (e.KeyCode == Keys.Left)
            {
                MoveSelectedPoints(0, 0, Globals.snapGrid, 0);
            }
            else if (e.KeyCode == Keys.Right)
            {
                MoveSelectedPoints(0, 0, 0, Globals.snapGrid);
            }
            else if (e.KeyCode == Keys.A && e.Control)
            {
                SelectAll();
            }
            else
            {
                //if not pass through to current tool
                VectorToolController.KeyDown(sender, e);
            }
        }

        public void MoveSelectedPointsRelative(Point offset)
        {
            foreach (Vector v in _drawing.Vectors)
            {
                //is the entire vector selected.. if so move both
                if (v.Start.Selected && v.End.Selected)
                {
                    v.Start.Point = v.Start.OriginalPoint.Add(offset.X, offset.Y);
                    v.End.Point = v.End.OriginalPoint.Add(offset.X, offset.Y);
                }
                else
                {
                    //vector not selected, move individual points
                    if (v.Start.Selected)
                    {
                        v.Start.Point = v.Start.OriginalPoint.Add(offset.X, offset.Y);
                    }
                    if (v.End.Selected)
                    {
                        v.End.Point = v.End.OriginalPoint.Add(offset.X, offset.Y);
                    }
                }
            }
        }

        public void MoveSelectedPoints(int up, int down, int left, int right)
        {
            foreach (Vector v in _drawing.Vectors)
            {
                if (v.Start.Selected)
                {
                    v.Start.Point.Add(right - left, down - up);
                }
                if (v.End.Selected)
                {
                    v.End.Point.Add(right - left, down - up);
                }
            }

            //for (int i = 0; i < allDistinctSelectedPoints)
            //{
            //    vp.Point.X = vp.Point.X + (right - left);
            //    vp.X += (right - left);
            //    vp.Y += (down - up);
            //    vp.Y += (down - up);
            //}
            //bool _selectedPointMatched = false;
            //if (_selectedPoint != null)
            //{
            //    foreach(Vector v in _drawing.Vectors)
            //    {
            //        if (v.Start.Matches(_selectedPoint))
            //        {
            //            v.Start.X += (right - left);
            //            v.Start.Y += (down - up);
            //            _selectedPointMatched = true;
            //        }
            //        if (v.End.Matches(_selectedPoint))
            //        {
            //            v.End.X += (right - left);
            //            v.End.Y += (down - up);
            //            _selectedPointMatched = true;
            //        }
            //    }
            //    if (_selectedPointMatched)
            //    {
            //        _selectedPoint = new Point(_selectedPoint.X + (right - left), _selectedPoint.Y + (down - up));
            //    }
            //}
            RedrawControl();
        }

        public void SaveOriginalPoints()
        {
            foreach (Vector v in _drawing.Vectors)
            {
                v.Start.OriginalPoint = v.Start.Point;
                v.End.OriginalPoint = v.End.Point;
            }
        }

        public void SelectAll()
        {
            foreach (Vector v in _drawing.Vectors)
            {
                v.Start.Selected = true;
                v.End.Selected = true;
            }
            RedrawControl();
        }

        public void SetZoom(float percentZoom)
        {
            float zoom = percentZoom / 100f;
            if (zoom > 0)
            {
                scaledPictureBox.SuspendDrawing();
                panel.SuspendDrawing();

                scaledPictureBox.SetZoom(zoom);
                panel.AutoScrollPosition = new Point((scaledPictureBox.Width - panel.Width) / 2, (scaledPictureBox.Height - panel.Height) / 2);
                
                scaledPictureBox.ResumeDrawing();
                panel.ResumeDrawing();
                this.ResumeLayout(true);
                RedrawControl();
            }
        }

        public void SetVectorWidth(int vectorWidth)
        {
            _vectorWidth = vectorWidth;
            RedrawControl();
        }

        public void Resize()
        {
            scaledPictureBox.ResizePictureBox();
            //Point centerPoint = new Point(scaledPictureBox.Width / 2, scaledPictureBox.Height / 2);
            //panel.AutoScrollPosition = centerPoint;
            //panel.AutoScrollMinSize = new Size()
        }

        public void FlipVectors(List<Guid> vectorsToFlip)
        {
            foreach (Guid guid in vectorsToFlip)
            {
                Vector vector = _drawing.Vectors.Where(v => v.Id == guid).FirstOrDefault();
                if (vector != null)
                {
                    Point oldStart = vector.Start.Point;
                    vector.Start.Point = vector.End.Point;
                    vector.End.Point = oldStart;
                }
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.MultiplyTransform(scaledPictureBox.ScaleM);
            //e.Graphics.TranslateTransform(scaledPictureBox.Width / 2, scaledPictureBox.Height / 2);
            e.Graphics.ScaleTransform(scaledPictureBox.Zoom, scaledPictureBox.Zoom);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //grey out of bounds
            //e.Graphics.FillRectangle(_boundsBrush, new Rectangle(_drawing.Extents.Width + 1, 0, scaledPictureBox.Width - _drawing.Size.Width + 1, scaledPictureBox.Height));
            //e.Graphics.FillRectangle(_boundsBrush, new Rectangle(0, _drawing.Extents.Height + 1, scaledPictureBox.Width, scaledPictureBox.Height-_drawing.Size.Height + 1));

            Point centerPoint = new Point(panel.Width / 2, panel.Height / 2);
            int minorGridOffsetX = centerPoint.X % _gridSize;
            int minorGridOffsetY = centerPoint.Y % _gridSize;
            int majorGridOffsetX = centerPoint.X % (_gridSize * 10);
            int majorGridOffsetY = centerPoint.Y % (_gridSize * 10);

            if (_showGrid)
            {
                for (int x = minorGridOffsetX; x < panel.Width; x += _gridSize)
                {
                    for (int y = minorGridOffsetY; y < panel.Height; y += _gridSize)
                    {
                        if (x % (_gridSize * 10) == majorGridOffsetX)
                        {
                            //draw vertical major axis for X (vertical lines)
                            e.Graphics.DrawLine(_majorAxisPen, new Point(x, 0), new Point(x, panel.Height));
                        }
                        else if (y % (_gridSize * 10) == majorGridOffsetY)
                        {
                            //draw vertical major axis for Y (horizontal lines)
                            e.Graphics.DrawLine(_majorAxisPen, new Point(0, y), new Point(panel.Width, y));
                        }
                        else
                        {
                            //draw minor dots
                            if (_drawing.ShowCenterPoint && centerPoint.Equals(x, y))
                            {
                                e.Graphics.FillRectangle(Brushes.Red, x, y, _gridDotSize, _gridDotSize); ;
                            }
                            else
                            {
                                e.Graphics.FillRectangle(_gridBrush, x, y, _gridDotSize, _gridDotSize);
                            }
                        }
                    }
                }
            }

            if (VectorToolController.DragStart != Point.Empty && VectorToolController.CurrentPosition != Point.Empty)
            {
                Point adjustedStart = VectorToolController.DragStart.Divide(scaledPictureBox.Zoom);
                Point adjustedEnd = VectorToolController.CurrentPosition.Divide(scaledPictureBox.Zoom);
                //e.Graphics.FillRectangle(Brushes.White, _dragStart.X-(_editDotSize/2), _dragStart.Y-(_editDotSize/2), _editDotSize, _editDotSize);
                switch (VectorToolController.DragShape)
                {
                    case DragShape.Line:
                        //draw a line from where the first point is to where the mouse is
                        e.Graphics.DrawLine(VectorToolController.Pen, adjustedStart, adjustedEnd);
                        break;
                    case DragShape.Rectangle:
                        Pen selectPen = new Pen(Color.LightYellow, 1);
                        selectPen.DashStyle = DashStyle.Dash;
                        e.Graphics.DrawRectangle(selectPen, GetRectangle(adjustedStart, adjustedEnd));
                        break;
                }

                //if (_dragEnd != Point.Empty)
                //{
                //    e.Graphics.FillRectangle(Brushes.White, _dragEnd.X - (_selectedDotSize/2), _dragEnd.Y - (_selectedDotSize/2), _selectedDotSize, _selectedDotSize);
                //    //draw a connecting line too
                //    e.Graphics.DrawLine(_selectedPen, _dragStart, _dragEnd);
                //}
            }

            Point pictureBoxCenter = new Point(panel.Width / 2, panel.Height / 2);

            if (_drawing != null)
            {
                Brush selectedBrush = Brushes.Yellow;
                Pen selectedVectorPen = new Pen(selectedBrush, _vectorWidth + 1);

                //draw non-selected vectors first (behind)
                foreach (Vector v in _drawing.Vectors.Where(v => !(v.Start.Selected && v.End.Selected) && v.Color != Color.Transparent))
                {
                    Pen vectorPen = new Pen(v.Color, _vectorWidth);
                    e.Graphics.DrawLine(vectorPen, v.Start.Point.Add(pictureBoxCenter), v.End.Point.Add(pictureBoxCenter));
                }
                //draw selected vectors now
                foreach (Vector v in _drawing.Vectors.Where(v => v.Start.Selected && v.End.Selected))
                {
                    Pen vectorPen = new Pen(v.Color, _vectorWidth + 1);
                    //draw dashed
                    vectorPen.DashStyle = DashStyle.Dash;
                    Point startPoint = v.Start.Point.Add(pictureBoxCenter);
                    Point endPoint = v.End.Point.Add(pictureBoxCenter);
                    e.Graphics.DrawLine(selectedVectorPen, startPoint, endPoint);
                    //draw end points to show selected..
                    DrawDot(startPoint, e.Graphics, selectedBrush, _vectorWidth + 1);
                    DrawDot(endPoint, e.Graphics, selectedBrush, _vectorWidth + 1);
                }

                List<Point> selectedPoints = _drawing.GetSelectedPoints();
                foreach (Point p in selectedPoints)
                {
                    DrawDot(p.Add(pictureBoxCenter), e.Graphics);
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            //Point snapLocation = GetSnapPoint(e.Location);
            VectorToolController.MouseDown(sender, e, e.Location, Control.ModifierKeys);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            //_lastMouseSnap = GetSnapPoint(e.Location);
            VectorToolController.MouseMove(sender, e, e.Location, Control.ModifierKeys);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //_lastMouseSnap = GetSnapPoint(e.Location);
            VectorToolController.MouseUp(sender, e, e.Location, Control.ModifierKeys);
        }

        private void scaledPictureBox_Resize(object sender, EventArgs e)
        {

        }

        public void CategorizeVectors (Vector scissorVector, Dictionary<Vector, VectorIntersectionInfo> intersectingVectors, Dictionary<Vector, VectorIntersectionInfo> leftSideVectors, Dictionary<Vector, VectorIntersectionInfo> rightSideVectors)
        {
            //need to adjust our scissor vector
            Point centerPoint = new Point(panel.Width / 2, panel.Height / 2);
            scissorVector.Start.Point = scissorVector.Start.Point.Subtract(centerPoint).Divide(scaledPictureBox.Zoom);
            scissorVector.End.Point = scissorVector.End.Point.Subtract(centerPoint).Divide(scaledPictureBox.Zoom);
            foreach (Vector v in VectorToolController.VectorPanel.GetDrawing().Vectors)
            {
                VectorIntersectionInfo info = VectorUtility.FindIntersection(scissorVector, v);
                if (info.SegmentsIntersect)
                {
                    intersectingVectors.Add(v, info);
                }
                else
                {
                    //no intersection, which side
                    //since no intersection, both points will be on the same side
                    //just use Point1 then
                    if (info.VectorStartSide == VectorIntersectionInfo.Side.Right)
                    {
                        rightSideVectors.Add(v, info);
                    }
                    else if (info.VectorStartSide == VectorIntersectionInfo.Side.Left)
                    {
                        leftSideVectors.Add(v, info);
                    }
                }
            }
        }

        public void CutVectors(Dictionary<Vector, VectorIntersectionInfo> intersectingVectors, Dictionary<Vector, VectorIntersectionInfo> leftSideVectors, Dictionary<Vector, VectorIntersectionInfo> rightSideVectors)
        {
            Dictionary<Vector, VectorIntersectionInfo> minorityVectors = rightSideVectors;
            Dictionary<Vector, VectorIntersectionInfo> majorityVectors = leftSideVectors;

            if (rightSideVectors.Count >= leftSideVectors.Count)
            {
                minorityVectors = leftSideVectors;
                majorityVectors = rightSideVectors;
            }

            //set a value for which 'side' the majority is on
            VectorIntersectionInfo.Side majoritySide = VectorIntersectionInfo.Side.Intersecting;
            if (majorityVectors.Count > 0)
            {
                majoritySide = majorityVectors.First().Value.VectorStartSide;
            }

            foreach (var vi in minorityVectors)
            {
                VectorToolController.VectorPanel.GetDrawing().Vectors.Remove(vi.Key);
            }

            KeyValuePair<Vector, VectorIntersectionInfo> leadingVector = intersectingVectors.ElementAt(0);
            KeyValuePair<Vector, VectorIntersectionInfo> laggingVector = intersectingVectors.ElementAt(1);

            //these are the vectors that need to be cut
            //which side is on the 'keep' side
            if (leadingVector.Value.VectorStartSide == majoritySide)
            {
                //trimmed vector will go from the start to the intersecting point
                leadingVector.Key.End.Point.X = (int)leadingVector.Value.ClosestPointOnVector2.X;
                leadingVector.Key.End.Point.Y = (int)leadingVector.Value.ClosestPointOnVector2.Y;
            }
            if (leadingVector.Value.VectorEndSide == majoritySide)
            {
                leadingVector.Key.Start.Point.X = (int)leadingVector.Value.ClosestPointOnVector2.X;
                leadingVector.Key.Start.Point.Y = (int)leadingVector.Value.ClosestPointOnVector2.Y;
            }
            //second vector
            if (laggingVector.Value.VectorStartSide == majoritySide)
            {
                //trimmed vector will go from the start to the intersecting point
                laggingVector.Key.End.Point.X = (int)laggingVector.Value.ClosestPointOnVector2.X;
                laggingVector.Key.End.Point.Y = (int)laggingVector.Value.ClosestPointOnVector2.Y;
            }
            if (laggingVector.Value.VectorEndSide == majoritySide)
            {
                laggingVector.Key.Start.Point.X = (int)laggingVector.Value.ClosestPointOnVector2.X;
                laggingVector.Key.Start.Point.Y = (int)laggingVector.Value.ClosestPointOnVector2.Y;
            }
            //intersecting vectors should now be trimmed
            //new vector will go from the intersecting point of this vector
            //to the intersecting point of the other vector
            Vector newVector = leadingVector.Key.Clone();
            switch (VectorToolSettings.ScissorCutLineColor)
            {
                case ScissorCutLineColor.LeadingVectorColor:
                    newVector.Color = leadingVector.Key.Color;
                    break;
                case ScissorCutLineColor.LaggingVectorColor:
                    newVector.Color = laggingVector.Key.Color;
                    break;
                case ScissorCutLineColor.Transparent:
                    newVector.Color = Color.Transparent;
                    break;
                case ScissorCutLineColor.DefaultColor:
                    newVector.Color = MainForm.GetSelectedColor();
                    break;
            }
            newVector.Start.Point = leadingVector.Key.End.Point;
            newVector.End.Point = laggingVector.Key.Start.Point;
            _drawing.Vectors.Insert(VectorToolController.VectorPanel.GetDrawing().Vectors.IndexOf(leadingVector.Key) + 1, newVector);
            RedrawControl();
        }

        public int MergePoints(int tolerance, bool countOnly, bool previewCandidates)
        {
            HashSet<Guid> mergedPointIds = new HashSet<Guid>();
            foreach(Vector v1 in _drawing.Vectors)
            {
                foreach(Vector v2 in _drawing.Vectors.Where(v => v.Id != v1.Id))
                {
                    if (!v1.Start.Point.Matches(v2.Start.Point) && v1.Start.Point.IsWithinCircle(v2.Start.Point, tolerance))
                    {
                        if (countOnly)
                        {
                            if (!mergedPointIds.Contains(v1.Start.Id))
                            {
                                mergedPointIds.Add(v1.Start.Id);
                                v1.Start.Selected = previewCandidates;
                            }
                            if (!mergedPointIds.Contains(v2.Start.Id))
                            {
                                mergedPointIds.Add(v2.Start.Id);
                                v2.Start.Selected = previewCandidates;
                            }
                        }
                        else
                        {
                            //do it - move second point to match first
                            v2.Start.Point = v1.Start.Point;
                        }
                    }
                    if (!v1.End.Point.Matches(v2.Start.Point) && v1.End.Point.IsWithinCircle(v2.Start.Point, tolerance))
                    {
                        if (countOnly)
                        {
                            if (!mergedPointIds.Contains(v1.End.Id))
                            {
                                mergedPointIds.Add(v1.End.Id);
                                v1.End.Selected = previewCandidates;
                            }
                            if (!mergedPointIds.Contains(v2.Start.Id))
                            {
                                mergedPointIds.Add(v2.Start.Id);
                                v2.Start.Selected = previewCandidates;
                            }
                        }
                        else
                        {
                            //do it - move second point to match first
                            v2.Start.Point = v1.End.Point;
                        }
                    }
                    if (!v1.Start.Point.Matches(v2.End.Point) && v1.Start.Point.IsWithinCircle(v2.End.Point, tolerance))
                    {
                        if (countOnly)
                        {
                            if (!mergedPointIds.Contains(v1.Start.Id))
                            {
                                mergedPointIds.Add(v1.Start.Id);
                                v1.Start.Selected = previewCandidates;
                            }
                            if (!mergedPointIds.Contains(v2.End.Id))
                            {
                                mergedPointIds.Add(v2.End.Id);
                                v2.End.Selected = previewCandidates;
                            }
                        }
                        else
                        {
                            //do it - move second point to match first
                            v2.End.Point = v1.Start.Point;
                        }
                    }
                    if (!v1.End.Point.Matches(v2.End.Point) && v1.End.Point.IsWithinCircle(v2.End.Point, tolerance))
                    {
                        if (countOnly)
                        {
                            if (!mergedPointIds.Contains(v1.End.Id))
                            {
                                mergedPointIds.Add(v1.End.Id);
                                v1.End.Selected = previewCandidates;
                            }
                            if (!mergedPointIds.Contains(v2.End.Id))
                            {
                                mergedPointIds.Add(v2.End.Id);
                                v2.End.Selected = previewCandidates;
                            }
                        }
                        else
                        {
                            //do it - move second point to match first
                            v2.End.Point = v1.End.Point;
                        }
                    }
                }
            }
            if (previewCandidates)
            {
                RedrawControl();
            }
            return mergedPointIds.Count();
        }
    }
}
