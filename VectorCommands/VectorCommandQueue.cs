using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public class VectorCommandQueue
    {
        private List<IVectorCommand> _commands = new List<IVectorCommand>();

        public void Add(IVectorCommand command)
        {
            _commands.Add(command);
        }

        public void Execute(Drawing drawing)
        {
            foreach(IVectorCommand command in _commands)
            {
                command.Execute(drawing);
            }
        }

        public void Undo(Drawing drawing)
        {
            //reversed
            for(int i = _commands.Count -1; i >= 0; i--)
            {
                _commands[i].Undo(drawing);
            }
        }

    }
}
