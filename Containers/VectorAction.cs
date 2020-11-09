using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public enum ActionType
    {
        Add,
        Delete,
        Edit
    }
    public class VectorAction
    {
        public ActionType Action { get; set; }
        public int Index { get; set; }
        public Vector Vector { get; set; }
        public Point Point { get; set; }
    }
}
