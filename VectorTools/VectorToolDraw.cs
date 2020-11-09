using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPaint.Tools
{
    public enum DrawToolState
    {
        Idle,
        Defining,
        Moving
    }

    public class VectorToolDraw : IVectorTool
    {
        private VectorPanel _vectorPanel = null;
        private DrawToolState _currentToolState = DrawToolState.Idle;
        private Point _selectedPoint = Point.Empty;
        private Point _dragStart = Point.Empty;

        public VectorToolDraw(VectorPanel vectorPanel)
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
                if (_currentToolState != DrawToolState.Idle)
                {
                    //start draw a line mode for tool
                    _dragStart = snapPoint;
                    if (_currentToolState == DrawToolState.Defining)
                    {
                        _currentToolState = DrawToolState.Defining;
                    }
                }
                else
                {
                    //finished
                    _vectorPanel.GetDrawing().Vectors.Add(new Vector(_dragStart, snapPoint, MainForm.GetSelectedColor()));
                    _dragStart = snapPoint;
                }
                _vectorPanel.RedrawControl();
            }
        }


        public void MouseMove(object sender, MouseEventArgs e, Point hitPoint, Keys modifierKeys)
        {
            if (_currentToolState == DrawToolState.Defining)
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
            else if (_currentToolState == DrawToolState.Idle)
            {
                Cursor.Current = Cursors.Default;
                _vectorPanel.RedrawControl();
            }
            else
            {
                //hit test for changing of cursor
                List<VectorPoint> hitVectorPoints = _vectorPanel.HitTest(hitPoint, true, false);
                if (hitVectorPoints.Count > 0)
                {
                    //draw cursor
                    Cursor.Current = Cursors.Hand;
                }
                else
                {
                    //normal cursor
                    Cursor.Current = Cursors.Default;
                }
            }

            Size currentVector = new Size(0, 0);
            if (_dragStart != Point.Empty)
            {
                currentVector = new Size(hitPoint.X - _dragStart.X, hitPoint.Y - _dragStart.Y);
            }
            Point relativePoint = new Point(hitPoint.X - _vectorPanel.GetDrawing().CenterPoint.X, hitPoint.Y - _vectorPanel.GetDrawing().CenterPoint.Y);
            _vectorPanel.OnReportCoordinates?.Invoke(hitPoint, relativePoint, currentVector);

        }

        public void MouseUp(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys)
        {

        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _dragStart = Point.Empty;
                _currentToolState = DrawToolState.Idle;
                _vectorPanel.ClearAllSelections();
                _vectorPanel.RedrawControl();
            }
        }
    }
}
