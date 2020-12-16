using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    [Serializable]
    public struct VectorPoint
    {
        public Point OriginalPoint;
        public Point Point;
        public bool Selected;
        public Guid Id;

    }
}
