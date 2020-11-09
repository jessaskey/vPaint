using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPaint
{
    public static class VectorUtility
    {

        public static Vector MergeVectors(Vector v1, Vector v2)
        {
            Vector tempVector = v1.Clone();

            double angle = AngleBetween(v1, v2);
            if (angle == 0)
            {
                if (v1.Start.Point.X == v2.Start.Point.X && v1.Start.Point.Y == v2.Start.Point.Y)
                {
                    tempVector.Start.Point = v1.End.Point;
                    tempVector.End.Point = v2.End.Point;
                }
                else if (v1.Start.Point.X == v2.End.Point.X && v1.Start.Point.Y == v2.End.Point.Y)
                {
                    tempVector.Start.Point = v1.End.Point;
                    tempVector.End.Point = v2.Start.Point;
                }
                else if (v1.End.Point.X == v2.Start.Point.X && v1.End.Point.Y == v2.Start.Point.Y)
                {
                    tempVector.Start.Point = v1.Start.Point;
                    tempVector.End.Point = v2.End.Point;
                }
                else if (v1.End.Point.X == v2.End.Point.X && v1.End.Point.Y == v2.End.Point.Y)
                {
                    tempVector.Start.Point = v1.Start.Point;
                    tempVector.End.Point = v2.Start.Point;
                }
            }

            return tempVector;
        }

        public static bool VectorsAreEqual(Vector v1, Vector v2)
        {
            return v1.Start.Point.X == v2.Start.Point.X && v1.Start.Point.Y == v2.Start.Point.Y && v1.End.Point.X == v2.End.Point.X && v1.End.Point.Y == v2.End.Point.Y;
        }

        public static double AngleBetween(Vector v1, Vector v2)
        {
            return Math.Abs(Math.Atan2(v1.Start.Point.Y - v1.Start.Point.Y, v1.End.Point.X - v1.Start.Point.X)) - Math.Abs(Math.Atan2(v2.End.Point.Y - v2.Start.Point.Y, v2.End.Point.X - v2.Start.Point.X));
        }

        public static VectorIntersectionInfo FindIntersection(Vector v1, Vector v2)
        {
            PointF p1 = v1.Start.Point;
            PointF p2 = v1.End.Point;
            PointF p3 = v2.Start.Point;
            PointF p4 = v2.End.Point;
            // Get the segments' parameters.
            float dx12 = p2.X - p1.X;
            float dy12 = p2.Y - p1.Y;
            float dx34 = p4.X - p3.X;
            float dy34 = p4.Y - p3.Y;

            VectorIntersectionInfo info = new VectorIntersectionInfo();
            // Solve for t1 and t2
            float denominator = (dy12 * dx34 - dx12 * dy34);
            float t1 = ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34) / denominator;
            //assuming v1 is the 'cut' vector, determin which side of v1 each point of v2 is on
            info.VectorStartSide = GetSide(((p2.X - p1.X) * (v2.Start.Point.Y - p1.Y) - (p2.Y - p1.Y) * (v2.Start.Point.X - p1.X)));
            info.VectorEndSide = GetSide(((p2.X - p1.X) * (v2.End.Point.Y - p1.Y) - (p2.Y - p1.Y) * (v2.End.Point.X - p1.X)));

            if (float.IsInfinity(t1))
            {
                // The lines are parallel (or close enough to it).
                info.LinesIntersect = false;
                info.SegmentsIntersect = false;
                info.IntersectionPoint = new PointF(float.NaN, float.NaN);
                info.ClosestPointOnVector1 = new PointF(float.NaN, float.NaN);
                info.ClosestPointOnVector2 = new PointF(float.NaN, float.NaN);
            }
            else
            {
                info.LinesIntersect = true;
                float t2 = ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12) / -denominator;
                // Find the point of intersection.
                info.IntersectionPoint = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);
                // The segments intersect if t1 and t2 are between 0 and 1.
                info.SegmentsIntersect = ((t1 >= 0) && (t1 <= 1) && (t2 >= 0) && (t2 <= 1));
                // Find the closest points on the segments.
                if (t1 < 0) { t1 = 0; } else if (t1 > 1) { t1 = 1; }
                if (t2 < 0) { t2 = 0; } else if (t2 > 1) { t2 = 1; }

                info.ClosestPointOnVector1 = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);
                info.ClosestPointOnVector2 = new PointF(p3.X + dx34 * t2, p3.Y + dy34 * t2);
            }
            return info;
        }

        private static VectorIntersectionInfo.Side GetSide(float value)
        {
            VectorIntersectionInfo.Side side = VectorIntersectionInfo.Side.Intersecting;
            if (value > 0)
            {
                side = VectorIntersectionInfo.Side.Left;
            }
            else
            {
                side = VectorIntersectionInfo.Side.Right;
            }
            return side;
        }
    }
}
