using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
    }
    public class VectorToolScissor : IVectorTool
    {
        private ScissorToolState _currentToolState = ScissorToolState.Idle;
        private Point _selectedPoint = Point.Empty;
        private Point _dragStart = Point.Empty;
        private Point _currentPosition = Point.Empty;
        private Pen _pen = new Pen(Brushes.White, 1) { DashStyle = DashStyle.Dash };

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
            get { return DragShape.Line; }
        }

        public Pen Pen
        {
            get { return _pen; }
        }

        public void MouseDown(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    switch (_currentToolState)
            //    {
            //        case ScissorToolState.Idle:
            //            //start draw a line mode for tool
            //            _dragStart = snapPoint;
            //            break;
            //    }
            //    VectorToolController.VectorPanel.RedrawControl();
            //}
        }


        public void MouseMove(object sender, MouseEventArgs e, Point hitPoint, Keys modifierKeys)
        {
            switch (_currentToolState)
            {
                case ScissorToolState.Idle:
                    Cursor.Current = Cursors.Default;
                    break;
                case ScissorToolState.Defining:
                    Cursor.Current = Cursors.Cross;
                    if (_dragStart != Point.Empty)
                    {
                        _currentPosition = hitPoint;
                    }
                    break;
            }
            VectorToolController.VectorPanel.RedrawControl();



            Size currentVector = new Size(0, 0);
            if (_dragStart != Point.Empty)
            {
                currentVector = new Size(hitPoint.X - _dragStart.X, hitPoint.Y - _dragStart.Y);
            }
            Point relativePoint = new Point(hitPoint.X - VectorToolController.VectorPanel.Drawing.CenterPoint.X, hitPoint.Y - VectorToolController.VectorPanel.Drawing.CenterPoint.Y);
            VectorToolController.VectorPanel.OnReportCoordinates?.Invoke(hitPoint, relativePoint, currentVector);
        }

        public void MouseUp(object sender, MouseEventArgs e, Point hitPoint, Keys modifierKeys)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (_currentToolState)
                {
                    case ScissorToolState.Idle:
                        _dragStart = hitPoint;
                        _currentToolState = ScissorToolState.Defining;
                        break;
                    case ScissorToolState.Defining:
                        //adjust to vector coordinates

                        Vector scissorVector = new Vector(_dragStart, hitPoint);
                        CutVectors(scissorVector);
                        _currentToolState = ScissorToolState.Idle;
                        break;
                }
            }

        }

        private void CutVectors(Vector scissorVector)
        {
            //find all vectors on each side of line
            Dictionary<Vector, VectorIntersectionInfo> rightSideVectors = new Dictionary<Vector, VectorIntersectionInfo>();
            Dictionary<Vector, VectorIntersectionInfo> leftSideVectors = new Dictionary<Vector, VectorIntersectionInfo>();
            Dictionary<Vector, VectorIntersectionInfo> intersectingVectors = new Dictionary<Vector, VectorIntersectionInfo>();
            VectorToolController.VectorPanel.CategorizeVectors(scissorVector, intersectingVectors, leftSideVectors, rightSideVectors);

            //which side has the most vectors
            if (intersectingVectors.Count == 0)
            {
                MessageBox.Show("Drawn line does not intersect any vectors. Do it again!");
                _currentToolState = ScissorToolState.Idle;
                _dragStart = Point.Empty;
            }
            else
            {
                if (intersectingVectors.Count % 2 != 0)
                {
                    MessageBox.Show("Scissor tool only supports cutting two vectors at a time. Do it again!");
                    _currentToolState = ScissorToolState.Idle;
                    _dragStart = Point.Empty;
                }
                else
                {
                    VectorToolController.VectorPanel.CutVectors(intersectingVectors, leftSideVectors, rightSideVectors);
                }
            }
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _dragStart = Point.Empty;
                _currentToolState = ScissorToolState.Idle;
                VectorToolController.VectorPanel.ClearAllSelections();
                VectorToolController.VectorPanel.RedrawControl();
            }
        }
    }
}
