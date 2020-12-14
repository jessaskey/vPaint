using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public interface IVectorCommand
    {
        void Execute(Drawing drawing);
        void Undo(Drawing drawing);
    }
}
