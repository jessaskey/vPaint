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
    public class VectorToolController
    {
        private VectorPanel _vectorPanel = null;
        private VectorTool _currentVectorTool = VectorTool.Selecting;
        private IVectorTool _currentVectorToolObject = null;

        private VectorToolSelect _toolSelect = null;
        private VectorToolDraw _toolDraw = null;
        private VectorToolScissor _toolScissor = null;

        public VectorToolController() { }

        public VectorToolController(VectorPanel vectorPanel)
        {
            _vectorPanel = vectorPanel;
            _toolSelect = new VectorToolSelect(vectorPanel);
            _toolDraw = new VectorToolDraw(vectorPanel);
            _toolScissor = new VectorToolScissor(vectorPanel);
            _currentVectorToolObject = _toolSelect;
        }

        public void MouseDown(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys)
        {
            _currentVectorToolObject.MouseDown(sender, e, snapPoint, modifierKeys);
        }

        public void MouseMove(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys)
        {
            _currentVectorToolObject.MouseMove(sender, e, snapPoint, modifierKeys);
        }

        public void MouseUp(object sender, MouseEventArgs e, Point snapPoint, Keys modifierKeys)
        {
            _currentVectorToolObject.MouseUp(sender, e, snapPoint, modifierKeys);
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            _currentVectorToolObject.KeyDown(sender, e);
        }

        public ToolAction CurrentToolAction = ToolAction.None;
        public VectorTool CurrentVectorTool
        {
            get { return _currentVectorTool; }
            set
            {
                _currentVectorTool = value;

            }
        }

        public Point DragStart
        {
            get { return _currentVectorToolObject.DragStart; }
        }

        public DragShape DragShape
        {
            get { return _currentVectorToolObject.DragShape; }
        }

    }
}
