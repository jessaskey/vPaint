using Svg.ExCSS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public static class Extensions
    {
        //public static Point Clone(this Point point )
        //{
        //    return new Point(point.X, point.Y);
        //}

        public static bool Matches(this Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static Point Add(this Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point Subtract(this Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Point Add(this Point p1, int x, int y)
        {
            return new Point(p1.X + x, p1.Y + y);
        }

        public static Point Subtract(this Point p1, int x, int y)
        {
            return new Point(p1.X - x, p1.Y - y);
        }

        public static Point Divide(this Point p1, float div)
        {
            return new Point((int)(((float)p1.X)/div),(int)(((float)p1.Y)/div));
        }

        public static bool Equals(this Point p1, int x, int y)
        {
            return p1.X == x && p1.Y == y;
        }

        public static bool IsWithinRectangle(this Point thisPoint, Point testPoint, int tolerance)
        {
            Rectangle rect = new Rectangle(thisPoint.X - (tolerance / 2), thisPoint.Y - (tolerance / 2), tolerance, tolerance);
            return rect.Contains(testPoint);
        }

        public static bool IsWithinCircle(this Point thisPoint, Point testPoint, int radius)
        {
            return Math.Pow((testPoint.X - thisPoint.X), 2) + Math.Pow((testPoint.Y - thisPoint.Y), 2) <= Math.Pow(radius,2);
        }


    }
}
