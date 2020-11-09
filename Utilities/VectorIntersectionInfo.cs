using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{

    public class VectorIntersectionInfo
    {
        public enum Side
        {
            Intersecting,
            Left, 
            Right
        }

        public bool LinesIntersect { get; set; }
        public bool SegmentsIntersect { get; set; }
        public PointF IntersectionPoint { get; set; }
        public PointF ClosestPointOnVector1 { get; set; }
        public PointF ClosestPointOnVector2 { get; set; }
        public Side VectorStartSide { get; set; }
        public Side VectorEndSide { get; set; }

    }
}
