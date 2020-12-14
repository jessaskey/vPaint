using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    public class VectorCommandController
    {
        private Drawing _drawing = null;

        private Stack<VectorCommandQueue> _queueStackNormal;
        private Stack<VectorCommandQueue> _queueStackReverse;
        private List<string> _actionHistory;

        public VectorCommandController(Drawing drawing)
        {
            _drawing = drawing;
            _queueStackNormal = new Stack<VectorCommandQueue>();
            _queueStackReverse = new Stack<VectorCommandQueue>();
            _actionHistory = new List<string>();
        }

        public void Execute(VectorCommandQueue commandQueue)
        {
            commandQueue.Execute(_drawing);
            _queueStackNormal.Push(commandQueue);
            _queueStackReverse.Clear();
            _actionHistory.Add(commandQueue.ToString());
        }

        public void Undo()
        {
            VectorCommandQueue commandQueue = _queueStackNormal.Pop();
            commandQueue.Undo(_drawing);
            _queueStackReverse.Push(commandQueue);
            _actionHistory.Add(commandQueue.ToString());
        }

        public void Redo()
        {
            VectorCommandQueue commandQueue = _queueStackReverse.Pop();
            commandQueue.Execute(_drawing);
            _queueStackNormal.Push(commandQueue);
            _actionHistory.Add(commandQueue.ToString());
        }

        //public void ClearNormal()
        //{
        //    _queueStackNormal.Clear();
        //}

        //public void ClearReverse()
        //{
        //    _queueStackReverse.Clear();
        //}

        public List<string> GetActionHistory()
        {
            return _actionHistory;
        }

    }

}
