using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPaint
{
    static class ExceptionController
    {
        public static void DisplayException(Exception ex)
        {
            ExceptionDialog ed = new ExceptionDialog();
            ed.SetException(ex);
            ed.ShowDialog();
        }
    }
}
