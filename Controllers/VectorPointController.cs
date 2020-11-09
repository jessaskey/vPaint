using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint.Controllers
{
    public static class VectorPointController
    {
        public static VectorPoint Create()
        {
            VectorPoint vp = new VectorPoint();
            vp.Id = Guid.NewGuid();
            return vp;
        }

        public static VectorPoint Create(Point point)
        {
            VectorPoint vp = new VectorPoint();
            vp.Id = Guid.NewGuid();
            vp.Point = point;
            return vp;
        }
    }
}
