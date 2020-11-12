using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VPaint.Tools;

namespace VPaint
{
    public static class VectorToolController
    {
        private static VectorPanel _vectorPanel = null;
        private static VectorTool _currentVectorTool = VectorTool.Selecting;
        private static IVectorTool _currentVectorToolObject = null;

        private static VectorToolSelect _toolSelect = new VectorToolSelect();
        private static VectorToolDraw _toolDraw = new VectorToolDraw();
        private static VectorToolScissor _toolScissor = new VectorToolScissor();

        //public VectorToolController() { }

        //public VectorToolController(VectorPanel vectorPanel)
        //{
        //    _vectorPanel = vectorPanel;
        //    //_toolSelect = new VectorToolSelect(vectorPanel);
        //    //_toolDraw = new VectorToolDraw(vectorPanel);
        //    //_toolScissor = new VectorToolScissor(vectorPanel);
        //    _currentVectorToolObject = _toolSelect;
        //}

        public static void MouseDown(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys)
        {
            _currentVectorToolObject?.MouseDown(sender, e, snapPoint, modifierKeys);
        }

        public static void MouseMove(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys)
        {
            _currentVectorToolObject?.MouseMove(sender, e, snapPoint, modifierKeys);
        }

        public static void MouseUp(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys)
        {
            _currentVectorToolObject?.MouseUp(sender, e, snapPoint, modifierKeys);
        }

        public static void KeyDown(object sender, KeyEventArgs e)
        {
            _currentVectorToolObject?.KeyDown(sender, e);
        }

        public static ToolAction CurrentToolAction = ToolAction.None;
        public static VectorTool CurrentVectorTool
        {
            get { return _currentVectorTool; }
            set
            {
                _currentVectorTool = value;
                switch (_currentVectorTool)
                {
                    case VectorTool.Selecting:
                        _currentVectorToolObject = _toolSelect;
                        break;
                    case VectorTool.Drawing:
                        _currentVectorToolObject = _toolDraw;
                        break;
                    case VectorTool.Scissors:
                        _currentVectorToolObject = _toolScissor;
                        break;
                }
            }
        }

        public static VectorPanel VectorPanel
        {
            get {
                return _vectorPanel;
            }
            set
            {
                _vectorPanel = value;
            }  
        }

        public static Point DragStart
        {
            get { return _currentVectorToolObject != null ? _currentVectorToolObject.DragStart : Point.Empty; }
        }

        public static Point CurrentPosition
        {
            get { return _currentVectorToolObject != null ? _currentVectorToolObject.CurrentPosition : Point.Empty; }
        }

        public static DragShape DragShape
        {
            get { return _currentVectorToolObject != null ? _currentVectorToolObject.DragShape : DragShape.Line; }
        }

        public static Pen Pen
        {
            get { return _currentVectorToolObject != null ? _currentVectorToolObject.Pen : Pens.Black; }
        }

    }
}
