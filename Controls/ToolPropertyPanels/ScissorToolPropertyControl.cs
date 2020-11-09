using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPaint.Controls
{
    public enum ScissorCutLineColor : int
    {
        LeadingVectorColor,
        LaggingVectorColor,
        Transparent,
        DefaultColor
    }

    public partial class ScissorToolPropertyControl : UserControl
    {
        public ScissorToolPropertyControl()
        {
            InitializeComponent();

            foreach (var e in Enum.GetNames(typeof(ScissorCutLineColor)))
            {
                comboBoxCutLineColor.Items.Add(e);
            }
            comboBoxCutLineColor.SelectedIndex = 0;
        }

        public ScissorCutLineColor CutLineColor
        {
            get
            {
                return (ScissorCutLineColor)comboBoxCutLineColor.SelectedIndex;
            }
            set
            {
                comboBoxCutLineColor.SelectedIndex = (int)value;
            }
        }

       
    }
}
