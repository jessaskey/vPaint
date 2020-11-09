using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPaint
{
    public partial class MergePointsDialog : Form
    {
        public VectorPanel VectorPanel { get; set; }
        public int MergeTolerance { get; set; }

        public MergePointsDialog()
        {
            InitializeComponent();
            MergeTolerance = (int)numericUpDownPointTolerance.Value;
            UpdatePreview();
        }

        private void numericUpDownPointTolerance_ValueChanged(object sender, EventArgs e)
        {
            MergeTolerance = (int)numericUpDownPointTolerance.Value;
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            if (VectorPanel != null)
            {
                int numberOfPoints = VectorPanel.MergePoints(MergeTolerance, true, checkBoxPreview.Checked);
                labelSummary.Text = numberOfPoints.ToString() + " points will be merged.";
            }
        }

        private void MergePointsDialog_Shown(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void checkBoxPreview_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }
    }
}
