using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPaint.Controls;

namespace VPaint.Tools
{
    public enum ScissorToolState
    {
        Idle,
        Defining,
        Defined,
    }
    public class VectorToolScissor : IVectorTool
    {
        private VectorPanel _vectorPanel = null;
        private ScissorToolState _currentToolState = ScissorToolState.Idle;
        private Point _selectedPoint = Point.Empty;
        private Point _dragStart = Point.Empty;

        public VectorToolScissor(VectorPanel vectorPanel)
        {
            _vectorPanel = vectorPanel;
        }

        public Point DragStart
        {
            get { return _dragStart; }
        }

        public DragShape DragShape
        {
            get { return DragShape.Line; }
        }

        public void MouseDown(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_currentToolState == ScissorToolState.Idle)
                {
                    //start draw a line mode for tool
                    _dragStart = snapPoint;
                    //draw a line for cutting
                    _currentToolState = ScissorToolState.Defining;
                }
                _vectorPanel.RedrawControl();
            }
        }


        public void MouseMove(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys)
        {
            if (_currentToolState == ScissorToolState.Defining)
            {
                Cursor.Current = Cursors.Cross;
                if (_dragStart != Point.Empty)
                {
                    int xDif = Math.Abs(_dragStart.X - e.X);
                    int yDif = Math.Abs(_dragStart.Y - e.Y);
                    if ((Control.ModifierKeys & Keys.Shift) != Keys.None)
                    {
                        if (xDif <= yDif)
                        {
                            if (xDif > 0)
                            {
                                _vectorPanel.OnUpdateCursor?.Invoke(new Point(_dragStart.X, e.Y));
                            }
                        }
                        else
                        {
                            if (yDif > 0)
                            {
                                _vectorPanel.OnUpdateCursor?.Invoke(new Point(e.X, _dragStart.Y));
                            }
                        }
                    }
                }
                _vectorPanel.RedrawControl();
            }
            else if (_currentToolState == ScissorToolState.Idle)
            {
                Cursor.Current = Cursors.Default;
                _vectorPanel.RedrawControl();
            }

            Size currentVector = new Size(0, 0);
            if (_dragStart != Point.Empty)
            {
                currentVector = new Size(snapPoint.X - _dragStart.X, snapPoint.Y - _dragStart.Y);
            }
            Point relativePoint = new Point(snapPoint.X - _vectorPanel.GetDrawing().CenterPoint.X, snapPoint.Y - _vectorPanel.GetDrawing().CenterPoint.Y);
            _vectorPanel.OnReportCoordinates?.Invoke(snapPoint, relativePoint, currentVector);

        }

        public void MouseUp(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys)
        {
            if (e.Button == MouseButtons.Left && _currentToolState == ScissorToolState.Defining)
            {
                Vector scissorVector = new Vector(_dragStart, snapPoint);
                //find all vectors on each side of line
                Dictionary<Vector, VectorIntersectionInfo> rightSideVectors = new Dictionary<Vector, VectorIntersectionInfo>();
                Dictionary<Vector, VectorIntersectionInfo> leftSideVectors = new Dictionary<Vector, VectorIntersectionInfo>();
                Dictionary<Vector, VectorIntersectionInfo> intersectingVectors = new Dictionary<Vector, VectorIntersectionInfo>();

                foreach (Vector v in _vectorPanel.GetDrawing().Vectors)
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

                //which side has the most vectors
                if (intersectingVectors.Count == 0)
                {
                    MessageBox.Show("Drawn line does not intersect any vectors. Do it again!");
                    _currentToolState = ScissorToolState.Idle;
                    _dragStart = Point.Empty;
                }
                else
                {
                    if (intersectingVectors.Count != 2)
                    {
                        MessageBox.Show("scissor tool only supports cutting two vectors at a time. Do it again!");
                        _currentToolState = ScissorToolState.Idle;
                        _dragStart = Point.Empty;
                    }
                    else
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
                            _vectorPanel.GetDrawing().Vectors.Remove(vi.Key);
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
                        _vectorPanel.GetDrawing().Vectors.Insert(_vectorPanel.GetDrawing().Vectors.IndexOf(leadingVector.Key) + 1, newVector);
                        _vectorPanel.RedrawControl();
                    }
                }
            }

        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _dragStart = Point.Empty;
                _currentToolState = ScissorToolState.Idle;
                _vectorPanel.ClearAllSelections();
                _vectorPanel.RedrawControl();
            }
        }
    }
}
