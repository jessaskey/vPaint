using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public class DrawVectorCommand : IVectorCommand
    {
        private Vector _vector = null;

        public DrawVectorCommand(Vector v)
        {
            _vector = v;
        }
        public void Execute(Drawing d)
        {
            d.Vectors.Add(_vector);
        }

        public void Undo(Drawing d)
        {
            d.Vectors.Remove(_vector);
        }
    }
}
