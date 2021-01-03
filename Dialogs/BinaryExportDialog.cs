using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPaint
{
    public partial class BinaryExportDialog : Form
    {
        private int _indent = 8;
        private List<Drawing> _allDrawings = new List<Drawing>();
        private Drawing _drawing = null;

        public BinaryExportDialog()
        {
            InitializeComponent();
        }

        public void SetDrawing(Drawing drawing, List<Drawing> allDrawings)
        {
            _allDrawings.Clear();
            _drawing = drawing;
            _allDrawings.AddRange(allDrawings);
        }

        public void UpdateSource()
        {
            textBoxSource.Text = "";
            StringBuilder sourceBuilder = new StringBuilder();
            Dictionary<Drawing, List<VectorSourceCommand>> drawingSources = new Dictionary<Drawing, List<VectorSourceCommand>>();
            //we always export with InvertY from Windows coords to Atari Coords
            VectorExportFlags exportFlags = VectorExportFlags.InvertY;
            if (checkBoxEncodeColorChanges.Checked) exportFlags |= VectorExportFlags.OutputColorChanges;
            if (checkBoxForceLongVectors.Checked) exportFlags |= VectorExportFlags.ForceLongVectors;
            if (checkBoxRTSL.Checked) exportFlags |= VectorExportFlags.AddRTSL;
            if (checkBoxAddSubroutines.Checked) exportFlags |= VectorExportFlags.GenerateSubroutines;
            if (checkBoxExportAll.Checked) exportFlags |= VectorExportFlags.PrependFileNameAsLabel;

            foreach (Drawing drawing in _allDrawings)
            {
                if (_drawing != null && !checkBoxExportAll.Checked && drawing != _drawing)
                {
                    continue;
                }
                List<VectorSourceCommand> sourceCommands = VectorSourceController.FromDrawing(drawing, exportFlags);
                drawingSources.Add(drawing, sourceCommands);
            }
            //do we need to parse to subroutines?
            if (exportFlags.HasFlag(VectorExportFlags.GenerateSubroutines))
            {
                List<KeyValuePair<SourceSegment<VectorSourceCommand>,int>> allCodeSegments = VectorSourceController.ParseSubroutines(drawingSources);
                var codeSegmentsFiltered = allCodeSegments.Where(p => p.Value >= (int)numericUpSubroutineUsages.Value && p.Key.GetSegments().Count >= (int)numericUpDownSubroutineElements.Value);

                //int bytesSaved = 0;
                //foreach (var kvp in codeSegmentsFiltered.OrderByDescending(k=>k.Key.GetSegments().Count))
                //{
                //    //print out each match, with the best subroutines identified first
                //    StringBuilder sb = new StringBuilder();
                //    int hits = kvp.Value;
                //    int elements = kvp.Key.List.Count;
                //    sb.AppendLine("Match with " + hits.ToString() + " hits and having " + elements.ToString() + " lines.");
                //    sb.AppendLine(kvp.Key.ToString());
                //    sb.AppendLine("");
                //    // sourceBuilder.AppendLine(sb.ToString());
                //    bytesSaved += (hits * (elements - 1));
                //}
                //sourceBuilder.AppendLine("Total Bytes Saved = " + bytesSaved.ToString() + "(" + bytesSaved.ToString("X4") + ")");
                //replace matches
                List<List<VectorSourceCommand>> subroutines = new List<List<VectorSourceCommand>>();
                foreach (var codeSegment in codeSegmentsFiltered)
                {
                    string subroutineLabel = textBoxSubroutinePrefix.Text + subroutines.Count.ToString("D2");
                    bool subroutineUsed = false;
                    foreach (var drawingSource in drawingSources)
                    {
                        bool added = VectorSourceController.InsertSubroutine(drawingSource.Value, codeSegment.Key, subroutineLabel);
                        if (added)
                        {
                            subroutineUsed = true;
                        }
                    }
                    if (subroutineUsed)
                    {
                        subroutines.Add(VectorSourceController.GetSubroutine(codeSegment.Key, subroutineLabel));
                    }
                }
                foreach (var ds in drawingSources)
                {
                    if (exportFlags.HasFlag(VectorExportFlags.AddRTSL))
                    {
                        ds.Value.Add(new VectorSourceCommand("rtsl"));
                    }
                    foreach (var s in ds.Value)
                    {
                        sourceBuilder.AppendLine(s.ToSourceString(10,50));
                    }
                    //separator
                    sourceBuilder.AppendLine("");
                }
                //add the actual subroutines to SourceCommands (at the end)
                foreach (var subroutine in subroutines)
                {
                    if (exportFlags.HasFlag(VectorExportFlags.AddRTSL))
                    {
                        subroutine.Add(new VectorSourceCommand("rtsl"));
                    }
                    foreach (var sourceLine in subroutine)
                    {
                        sourceBuilder.AppendLine(sourceLine.ToSourceString(10,50));
                    }
                    sourceBuilder.AppendLine("");
                }
            }
            else
            {
                foreach(var ds in drawingSources)
                {
                    if (exportFlags.HasFlag(VectorExportFlags.AddRTSL))
                    {
                        ds.Value.Add(new VectorSourceCommand("rtsl"));
                    }
                    foreach (var s in ds.Value)
                    {
                        sourceBuilder.AppendLine(s.ToSourceString(10,50));
                    }
                    //separator
                    sourceBuilder.AppendLine("");
                }
            } 
            textBoxSource.Text = sourceBuilder.ToString();
        }

        private void checkBoxForceLongVectors_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSource();
        }

        private void checkBoxEncodeColorChanges_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSource();
        }

        private void buttonCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxSource.Text);
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Assembly Language Files(*.asm) | *.asm|All Files (*.*)|*.*";
            DialogResult dr = sd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(sd.FileName, textBoxSource.Text);
                this.Close();
            }
        }

        private void checkBoxExportAll_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSource();
        }

        private void checkBoxMinimize_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSource();
        }

        private void checkBoxAddSubroutines_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSubroutines.Enabled = checkBoxAddSubroutines.Checked;
            UpdateSource();
        }

        private void checkBoxRTSL_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSource();
        }

        private void numericUpSubroutineUsages_ValueChanged(object sender, EventArgs e)
        {
            UpdateSource();
        }

        private void numericUpDownSubroutineElements_ValueChanged(object sender, EventArgs e)
        {
            UpdateSource();
        }
    }
}
