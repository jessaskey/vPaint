using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public class DeleteVectorCommand : IVectorCommand
    {
        List<Vector> _vectors = null;
        public DeleteVectorCommand(List<Vector> vectors)
        {
            _vectors = vectors;
        }

        public DeleteVectorCommand(Vector vector)
        {
            _vectors = new List<Vector>() { vector };
        }

        public void Execute(Drawing d)
        {
            _vectors.ForEach(v => d.Vectors.Remove(v));
        }

        public void Undo(Drawing d)
        {
            _vectors.ForEach(v => d.Vectors.Add(v));
        }
    }
}
