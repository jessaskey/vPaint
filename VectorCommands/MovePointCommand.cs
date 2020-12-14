using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public class MovePointCommand : IVectorCommand
    {
        List<Tuple<VectorPoint, Point>> _points = new List<Tuple<VectorPoint, Point>>();

        public MovePointCommand(List<Tuple<VectorPoint, Point>> points)
        {
            _points = points;
        }

        public MovePointCommand(VectorPoint pointCurrent, Point pointNew)
        {
            _points = new List<Tuple<VectorPoint, Point>>() { new Tuple<VectorPoint, Point>(pointCurrent, pointNew) };
        }

        public void Execute(Drawing d)
        {
            foreach (var p in _points)
            {
                foreach (Vector v in d.Vectors.Where(v => v.Start.Id == p.Item1.Id))
                {
                    v.Start.Point = p.Item2;
                }
                foreach (Vector v in d.Vectors.Where(v => v.End.Id == p.Item1.Id))
                {
                    v.End.Point = p.Item2;
                }
            }
        }

        public void Undo(Drawing d)
        {
            foreach (var p in _points)
            {
                foreach (Vector v in d.Vectors.Where(v => v.Start.Id == p.Item1.Id))
                {
                    v.Start.Point = p.Item1.Point;
                }
                foreach (Vector v in d.Vectors.Where(v => v.End.Id == p.Item1.Id))
                {
                    v.End.Point = p.Item1.Point;
                }
            }
        }
    }
}
