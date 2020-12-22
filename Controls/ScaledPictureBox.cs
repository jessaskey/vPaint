using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace VPaint
{
    public class ScaledPictureBox : PictureBox
    {
        private float _zoom = 1.00f;

        //private Size _baseSize = Size.Empty;
        //public Matrix ScaleM { get; set; }

        public float Zoom
        {
            get
            {
                return _zoom;
            }
        } 

        public ScaledPictureBox()
        {
            //ScaleM = new Matrix();
            SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void ResizePictureBox()
        {
            //our size will always be the parent size * current zoom
            Size = new Size((int)(Parent.Width * _zoom), (int)(Parent.Height * _zoom));
        }

        public void SetZoom(float zoom)
        {
            _zoom = zoom;
            ResizePictureBox();
            Invalidate();
        }

        public PointF ScalePoint(PointF pt)
        {
            return new PointF(pt.X / Zoom, pt.Y / Zoom);
        }

    }
}
