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
    public partial class ExceptionDialog : Form
    {

        public ExceptionDialog()
        {
            InitializeComponent();
        }

        public void SetException(Exception ex)
        {
            textBoxMessage.Text = ex.Message;
            textBoxSource.Text = ex.Source;
            textBoxStack.Text = ex.StackTrace;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
