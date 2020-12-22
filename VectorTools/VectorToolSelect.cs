using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace VPaint.Tools
{

    public enum SelectToolState
    {
        Idle,   //initial status
        Selected, //once selected, if you click and drag, then the selected things will move
        Moving
    }

    public class VectorToolSelect : IVectorTool
    {
        private SelectToolState _currentToolState = SelectToolState.Idle;
        private Point _selectedPoint = Point.Empty;
        private Point _dragStart = Point.Empty;
        private Point _currentPosition = Point.Empty;
        private Pen _pen = new Pen(Brushes.Yellow, 1);

        public Point DragStart
        {
            get { return _dragStart; }
        }

        public Point CurrentPosition
        {
            get { return _currentPosition; }
        }

        public DragShape DragShape
        {
            get { return DragShape.Rectangle; }
        }

        public Pen Pen
        {
            get { return _pen; }
        }

        public bool UsesSnap
        {
            get { return false; }
        }

        public void MouseDown(object sender, MouseEventArgs e, Point hitPoint, Keys modifierKeys, int currentSnap)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (_currentToolState)
                {
                    case SelectToolState.Idle:
                    case SelectToolState.Selected:
                        List<VectorPoint> hitVectorPoint = VectorToolController.VectorPanel.HitTest(hitPoint, false, false);
                        //if any of the hit items are not selected already, then we have a miss
                        bool miss = hitVectorPoint.Count() == 0 || hitVectorPoint.Where(p => !p.Selected).Count() > 0;
                        if ((modifierKeys & Keys.Control) == Keys.None && miss)
                        {
                            VectorToolController.VectorPanel.ClearAllSelections();
                        }

                        if (!miss)
                        {
                            //mark all the points original locations because we may be moving next
                            VectorToolController.VectorPanel.SaveOriginalPoints();
                            _currentToolState = SelectToolState.Moving;        
                            _dragStart = hitPoint;
                        }
                        break;
                }
                //if (_currentToolState == SelectToolState.Idle)
                //{
                //if '
                //(Control.ModifierKeys & Keys.Shift) != Keys.None
                ///{
                //force select

                //}
                //else
                //{
                //    //are we at the current selected point? If so we are moving the point
                //    if (_selectedPoint != Point.Empty && _selectedPoint.X == snapPoint.X && _selectedPoint.Y == snapPoint.Y)
                //    {
                //        _currentToolState = SelectToolState.Moving;
                //        Cursor.Current = Cursors.Arrow;
                //    }
                //}
                //}
                //else
                //{
                //    //was moving, finish it up now..
                //    _currentToolState = SelectToolState.Idle;
                //    _dragStart = Point.Empty;
                //    Cursor.Current = Cursors.Default;
                //}
                VectorToolController.VectorPanel.RedrawControl();
            }
            //else if (e.Button == MouseButtons.Right)
            //{
            //    //selecting here...
            //    _dragStart = snapPoint;
            //    _currentToolState = SelectToolState.Selected;
            //}
        }


        public void MouseMove(object sender, MouseEventArgs e, Point hitPoint, Keys modifierKeys, int currentSnap)
        {
            //no button action, for cursors
            switch (_currentToolState)
            {
                case SelectToolState.Selected:
                    List<VectorPoint> hitVectorPoints = VectorToolController.VectorPanel.HitTest(hitPoint, true, false);
                    if (hitVectorPoints.Count > 0)
                    {
                        //move cursor
                        Cursor.Current = Cursors.SizeAll;
                    }
                    else
                    {
                        //normal cursor
                        Cursor.Current = Cursors.Default;
                    }
                    break;
            }
            //Now button actions
            if (e.Button == MouseButtons.Left)
            {
                switch (_currentToolState)
                {
                    case SelectToolState.Moving:
                        if (_dragStart != Point.Empty)
                        {
                            int xDif = e.X - _dragStart.X;
                            int yDif = e.Y - _dragStart.Y;
                            if (xDif != 0 || yDif != 0)
                            {
                                VectorToolController.VectorPanel.MoveSelectedPointsRelative(new Point(xDif, yDif));
                            }
                        }
                        VectorToolController.VectorPanel.RedrawControl();
                        break;
                }
            }

            else if (_currentToolState == SelectToolState.Moving)
            {
                Cursor.Current = Cursors.Hand;
                //find all vectors that have the current selected point and update them to the 
                //latest mouse snap point

                if (_selectedPoint != Point.Empty)
                {
                    var startPointVectors = VectorToolController.VectorPanel.Drawing.Vectors.Where(v => v.Start.Point.Matches(_selectedPoint));
                    foreach (Vector v in startPointVectors)
                    {
                        v.Start.Point = hitPoint;
                    }
                    var endPointVectors = VectorToolController.VectorPanel.Drawing.Vectors.Where(v => v.End.Point.Matches(_selectedPoint));
                    foreach (Vector v in endPointVectors)
                    {
                        v.End.Point = hitPoint;
                    }
                    _selectedPoint = hitPoint;
                }
                VectorToolController.VectorPanel.RedrawControl();
            }
            else if (_currentToolState == SelectToolState.Idle)
            {
                Cursor.Current = Cursors.Default;
                VectorToolController.VectorPanel.RedrawControl();
            }
            else
            {
                //hit test for changing of cursor
                //VectorPoint? p = _vectorPanel.FindVectorPoint(snapPoint);
                //if (p != null)
                //{
                //    Cursor.Current = Cursors.Default;
                //}
                //else if (_vectorPanel.FindVector(snapPoint) != null)
                //{
                //    Cursor.Current = Cursors.Default;
                //}

            }

            Size currentVector = new Size(0, 0);
            if (_dragStart != Point.Empty)
            {
                currentVector = new Size(hitPoint.X - _dragStart.X, hitPoint.Y - _dragStart.Y);
            }
            Point relativePoint = new Point(hitPoint.X - VectorToolController.VectorPanel.Drawing.CenterPoint.X, hitPoint.Y - VectorToolController.VectorPanel.Drawing.CenterPoint.Y);
            VectorToolController.VectorPanel.OnReportCoordinates?.Invoke(hitPoint, relativePoint, currentVector);
        }

        public void MouseUp(object sender, MouseEventArgs e, Point hitPoint, Keys modifierKeys, int currentSnap)
        {
            _dragStart = Point.Empty;
            Cursor.Current = Cursors.Default;
            if (e.Button == MouseButtons.Right)
            {
                switch (_currentToolState)
                {
                    case SelectToolState.Idle:
                        //select all vectors in rectangle
                        Rectangle rect = new Rectangle(_dragStart, new Size(hitPoint.X - _dragStart.X, hitPoint.Y - _dragStart.Y));
                        foreach (Vector v in VectorToolController.VectorPanel.Drawing.Vectors)
                        {
                            v.Start.Selected = rect.Contains(v.Start.Point);
                            v.End.Selected = rect.Contains(v.End.Point);
                        }
                        break;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                switch (_currentToolState)
                {
                    case SelectToolState.Idle:
                    case SelectToolState.Selected:
                        //if matched, then add
                        List<VectorPoint> hitVectorPoints = VectorToolController.VectorPanel.HitTest(hitPoint, false, true);
                        if (hitVectorPoints.Count > 0)
                        {
                            _currentToolState = SelectToolState.Selected;
                        }
                        break;
                    case SelectToolState.Moving:
                        //Have we moved enough
                        if (_dragStart != hitPoint)
                        {
                            //save it
                            List<VectorPoint> selectedPoints = VectorToolController.VectorPanel.Drawing.GetSelectedPoints();
                            VectorToolController.VectorPanel.MovePoints(selectedPoints);
                            //go back
                            _currentToolState = SelectToolState.Selected;
                            _dragStart = Point.Empty;
                        }
                        break;
                }
            }
            VectorToolController.VectorPanel.RedrawControl();
        }

        public void KeyDown(object sender, KeyEventArgs e, int currentSnap)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _dragStart = Point.Empty;
                _currentToolState = SelectToolState.Idle;
                VectorToolController.VectorPanel.ClearAllSelections();
                VectorToolController.VectorPanel.RedrawControl();
            }
        }


    }
}
