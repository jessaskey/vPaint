﻿using System;
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
    [Flags]
    public enum VectorTransform : int
    {
        None = 0,
        FlipX = 1,
        FlipY = 2
    }

    public partial class ImportDialog : Form
    {
        public Point StartPoint = Point.Empty;
        public List<Vector> Vectors = new List<Vector>();
        public Color VectorColor = Color.White;
        public VectorTransform Transform = VectorTransform.None;

        public ImportDialog()
        {
            InitializeComponent();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            List<VectorSourceCommand> sourceCommands = VectorSourceController.Parse(textBoxImport.Text, StartPoint);
            Point lastPoint = StartPoint;

            foreach (VectorSourceCommand command in sourceCommands)
            {
                
                switch (command.Command.ToLower())
                {
                    case "vctr":
                    case "vctrl":
                        if (command.Parameters.Count == 3)
                        {
                            int x = VectorSourceController.ParseIntValue(command.Parameters[0]);
                            int y = VectorSourceController.ParseIntValue(command.Parameters[1]);  //GetNumberParameter(parms[1]) * -1;
                            if (Transform.HasFlag(VectorTransform.FlipX))
                            {
                                x = x * -1;
                            }
                            if (Transform.HasFlag(VectorTransform.FlipY))
                            {
                                y = y * -1;
                            }
                            
                            Point thisPoint = new Point(x + lastPoint.X, y + lastPoint.Y);
                            Color color = Color.Transparent;

                            //if (thisPoint != StartPoint)
                            //{
                                color = (command.Parameters[2].ToLower() == "visible") ? VectorColor : Color.Transparent;
                            //}
                            Vector v = new Vector(lastPoint, thisPoint, color);
                            Vectors.Add(v);
                            lastPoint = thisPoint;
                        }
                        else
                        {
                            command.ParserError = "Incorrect number of Parameters... expected 3, found " + command.Parameters.Count.ToString();
                        }
                        break;
                }
            }
            //foreach(string line in textBoxImport.Text.Split(new char[] { '\r','\n'}, StringSplitOptions.RemoveEmptyEntries))
            //{
            //    string[] parms = GetParms(line);
            //    string command = GetCommand(line);
            //    string comment = GetComment(line);
            //    switch (command)
            //    {
            //        case "vctr":
            //        case "vctrl":
            //            int x = GetNumberParameter(parms[0]);
            //            int y = GetNumberParameter(parms[1])*-1;
            //            Point thisPoint = new Point(x+lastPoint.X, y+ lastPoint.Y);
            //            Color color = Color.Transparent;

            //            if (lastPoint != Point.Empty)
            //            {
            //                color = (parms[2].ToLower() == "visible") ? VectorColor : Color.Transparent;
            //            }

            //            Vector v = new Vector(lastPoint, thisPoint, color);
            //            Vectors.Add(v);
            //            lastPoint = thisPoint;

            //            break;
            //    }
            //}
            Close();
        }
    }
}
