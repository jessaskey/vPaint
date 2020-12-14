using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPaint
{
    public partial class ImportDialog : Form
    {
        public Point StartPoint = Point.Empty;
        public List<Vector> Vectors = new List<Vector>();
        public Color VectorColor = Color.White;

        public ImportDialog()
        {
            InitializeComponent();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            Point lastPoint = StartPoint;

            foreach(string line in textBoxImport.Text.Split(new char[] { '\r','\n'}, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] parms = GetParms(line);
                string command = GetCommand(line);
                string comment = GetComment(line);
                switch (command)
                {
                    case "vctr":
                    case "vctrl":
                        int x = GetNumberParameter(parms[0]);
                        int y = GetNumberParameter(parms[1])*-1;
                        Point thisPoint = new Point(x+lastPoint.X, y+ lastPoint.Y);
                        Color color = Color.Transparent;

                        if (lastPoint != Point.Empty)
                        {
                            color = (parms[2].ToLower() == "visible") ? VectorColor : Color.Transparent;
                        }

                        Vector v = new Vector(lastPoint, thisPoint, color);
                        Vectors.Add(v);
                        lastPoint = thisPoint;

                        break;
                }
            }
            Close();
        }

        private int GetNumberParameter(string parm)
        {
            int val = 0;
            if (!int.TryParse(parm, out val))
            {
                if (parm.Contains("d"))
                {
                    val = int.Parse(parm.Replace("d", ""));
                }
            }

            return val;
        }

        private string GetCommand(string line)
        {
            Regex r = new Regex(@"^[ \f\t\v]*(\w*)\(?");
            Match m = r.Match(line);
            if (m.Success)
            {
                if (m.Groups.Count > 1)
                {
                    return m.Groups[1].Value.ToLower();
                }
                
            }
            return String.Empty;
        }

        private string GetComment(string line)
        {
            string comment = "";
            if (line.Contains(";"))
            {

            }
            return comment;
        }

        private string[] GetParms(string line)
        {
            Regex r = new Regex(@"\((.*?)\)");
            Match m = r.Match(line);
            if (m.Success)
            {
                if (m.Groups.Count > 1)
                {
                    return m.Groups[1].Value.Split(',');
                }
            }
            return new List<string>().ToArray();
        }
    }
}
