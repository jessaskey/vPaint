using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPaint
{
    public class ToolTabPage : TabPage
    {

        public T GetToolControl<T>()
        {
            var controls = this.Controls.Cast<T>();
            return controls.Where(c => c.GetType() == typeof(T)).FirstOrDefault();
        }
    }
}
