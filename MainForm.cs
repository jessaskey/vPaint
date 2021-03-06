﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace VPaint
{
    public partial class MainForm : Form
    {
        private static ColorPicker _colorPicker = null;
        private ReportCoordinatesDelegate _reportCoordinates = null;
        //private VectorTool _currentPaletteTool = VectorTool.Selecting;
        //private UpdateCursorDelegate _updateCursor = null;
        //private UpdateStatusDelegate _updateStatus = null;

        public MainForm()
        {
            InitializeComponent();
            _reportCoordinates = new ReportCoordinatesDelegate(ReportCoordinates);
            //_updateCursor = new UpdateCursorDelegate(UpdateCursor);
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            toolStrip1.SuspendLayout();
            //add color picker to toolstrip
            _colorPicker = new ColorPicker();
            _colorPicker.AddStandardColors();
            _colorPicker.SelectedIndex = 4;
            ToolStripControlHost toolStripControlHost = new ToolStripControlHost(_colorPicker);
            toolStripControlHost.Width = _colorPicker.Width+5;
            toolStrip1.Items.Insert(toolStrip1.Items.IndexOf(toolStripLabelColor)+1, toolStripControlHost);
            //add snap to grid
            NumericUpDown upDownSnap = new NumericUpDown();
            upDownSnap.Minimum = 1;
            upDownSnap.Maximum = 20;
            upDownSnap.Value = Globals.snapGrid;
            upDownSnap.ValueChanged += (s,args) => {
                Globals.snapGrid = (int)upDownSnap.Value;
            };
            ToolStripControlHost toolStripControlHostSnap = new ToolStripControlHost(upDownSnap);
            toolStripControlHostSnap.Width = upDownSnap.Width + 5;
            toolStrip1.Items.Insert(toolStrip1.Items.IndexOf(toolStripLabelSnapGrid)+1, toolStripControlHostSnap);
            //add zoom
            NumericUpDown upDownZoom = new NumericUpDown();
            upDownZoom.Minimum = 10;
            upDownZoom.Maximum = 3000;
            upDownZoom.Value = Globals.zoomLevel;
            upDownZoom.Increment = 10;
            upDownZoom.ValueChanged += (s, args) => {
                Globals.zoomLevel = (int)upDownZoom.Value;
                GetCurrentVectorPanel()?.SetZoom(Globals.zoomLevel);
            };
            ToolStripControlHost toolStripControlHostZoom = new ToolStripControlHost(upDownZoom);
            toolStripControlHostZoom.Width = upDownSnap.Width + 5;
            toolStrip1.Items.Insert(toolStrip1.Items.IndexOf(toolStripLabelZoom)+1, toolStripControlHostZoom);
            //add vector width
            NumericUpDown upDownVectorWidth = new NumericUpDown();
            upDownVectorWidth.Minimum = 1;
            upDownVectorWidth.Maximum = 10;
            upDownVectorWidth.Value = Globals.vectorWidth;
            upDownVectorWidth.Increment = 1;
            upDownVectorWidth.ValueChanged += (s, args) => {
                Globals.vectorWidth = (int)upDownVectorWidth.Value;
                GetCurrentVectorPanel()?.SetVectorWidth(Globals.vectorWidth);
            };
            ToolStripControlHost toolStripControlHostVectorWidth = new ToolStripControlHost(upDownVectorWidth);
            toolStripControlHostVectorWidth.Width = upDownVectorWidth.Width + 5;
            toolStrip1.Items.Insert(toolStrip1.Items.IndexOf(toolStripLabelVectorWidth) + 1, toolStripControlHostVectorWidth);
            toolStrip1.ResumeLayout();

            //open new drawing on startup
            //NewDrawing();
            //_currentPaletteTool = PaletteTool.Selecting;
            SetCurrentTool(VectorTool.Selecting);
            numericUpDownEllipseVertices.Value = VectorToolSettings.EllipseVertexCount;
        }

        public void ReportCoordinates(Point absoluteCoordinate, Point relativeCoordinate, Size currentVector)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("POS(");
            sb.Append(relativeCoordinate.X.ToString());
            sb.Append(",");
            sb.Append(relativeCoordinate.Y.ToString());
            sb.Append(")[");
            sb.Append(absoluteCoordinate.X.ToString());
            sb.Append(",");
            sb.Append(absoluteCoordinate.Y.ToString());
            sb.Append("] VECTOR(");
            sb.Append(currentVector.Width.ToString());
            sb.Append(",");
            sb.Append((currentVector.Height * -1).ToString());
            sb.Append(")"); ;
            toolStripStatusLabelCoordinates.Text = sb.ToString();
            statusStrip1.Refresh();
        }

        public void UpdateCursor(Point p)
        {
            VectorPanel v = GetCurrentVectorPanel();
            if (v != null)
            {
                Cursor.Position = v.PointToScreen(p);
            }
        }

        public void VectorChanged()
        {
            LoadVectors(GetCurrentDrawing());
        }

        public void LoadVectors(Drawing drawing)
        {
            listViewVectors.Items.Clear();
            if (drawing != null)
            {
                int number = 1;
                listViewVectors.BeginUpdate();
                foreach (Vector v in drawing.Vectors)
                {
                    ListViewItem item = new ListViewItem(number.ToString());
                    item.SubItems.Add(v.ToString(drawing.CenterPoint));
                    item.SubItems.Add(v.DisplayColor == Color.Transparent ? "Hidden" : "Visible");
                    item.Tag = v;
                    listViewVectors.Items.Add(item);
                    number++;
                }
                listViewVectors.EndUpdate();
            }
        }

        public void UpdateStatus(string s)
        {
            toolStripStatusLabelStatus.Text = s;
            statusStrip1.Refresh();
        }

        private VectorPanel GetCurrentVectorPanel()
        {
            if (tabControlImages.TabPages.Count > 0)
            {
                TabPage currentPage = tabControlImages.SelectedTab;
                if (currentPage != null)
                {
                    return currentPage.Tag as VectorPanel;
                }
            }
            return null;
        }

        private Drawing GetCurrentDrawing()
        {
            TabPage currentPage = tabControlImages.SelectedTab;
            VectorPanel vp = currentPage.Tag as VectorPanel;
            return vp?.Drawing;
        }

        public static Color GetSelectedColor()
        {
            return _colorPicker.SelectedValue;
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            NewDrawing();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            OpenDrawing();
        }

        private string GetNextFileName()
        {
            for(int i = 1; i < 100; i++)
            {
                string fileName = "NewImage" + i.ToString();
                bool found = false;
                foreach (TabPage page in tabControlImages.TabPages)
                {
                    VectorPanel vp = page.Tag as VectorPanel;
                    if (vp != null)
                    {
                        Drawing d = vp.Drawing;
                        if (d != null)
                        {
                            if (d.FileName.ToLower() == fileName.ToLower())
                            {
                                found = true;
                            }
                        }
                    }
                }
                if (!found)
                {
                    return fileName;
                }
            }
            return "BadShitSon";
        }

        private void NewDrawing()
        {
            Drawing newDrawing = new Drawing(GetNextFileName());
            newDrawing.ShowCenterPoint = true;
            EditDrawing(newDrawing);
        }

        private void OpenDrawing()
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Atari Vector Drawing | *.avd";
            od.Multiselect = true;
            od.CheckFileExists = true;

            DialogResult dr = od.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string filename in od.FileNames)
                {
                    LoadDrawing(filename);
                }
            }
        }

        private void LoadDrawing(string currentDrawingFileName)
        {
            if (File.Exists(currentDrawingFileName))
            {
                // Now we can read the serialized book ...  
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Drawing));
                System.IO.StreamReader file = new System.IO.StreamReader(currentDrawingFileName);
                Drawing drawing = (Drawing)reader.Deserialize(file);
                //also unselect anything selected
                foreach(Vector v in drawing.Vectors)
                {
                    v.Start.Selected = false;
                    v.End.Selected = false;
                }
                //temp fix for bug that was not updating the filename property after saving
                drawing.FileName = Path.GetFileName(currentDrawingFileName);
                drawing.IsDirty = false;
                VectorPanel vp = EditDrawing(drawing);
                vp.DrawingPath = Path.GetDirectoryName(currentDrawingFileName);
                file.Close();
            }
        }

        private VectorPanel EditDrawing(Drawing drawing)
        {
            TabPage page = new TabPage();
            VectorPanel vectorPanel = new VectorPanel(drawing);
            vectorPanel.OnReportCoordinates = _reportCoordinates;
            vectorPanel.OnUpdateCursor = UpdateCursor;
            vectorPanel.OnUpdateStatus = UpdateStatus;
            vectorPanel.Dock = DockStyle.Fill;
            VectorToolController.VectorPanel = vectorPanel;
            //vectorPanel.SetCurrentTool(_currentPaletteTool);

            page.Controls.Add(vectorPanel);
            page.Tag = vectorPanel;
            page.Text = drawing.GetFilenameTitle();;
            tabControlImages.TabPages.Add(page);
            tabControlImages.SelectedTab = page;

            drawing.OnVectorCollectionChanged = VectorChanged;
            vectorPanel.Resize();
            LoadVectors(drawing);
            return vectorPanel;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            Drawing drawing = GetCurrentDrawing();
            SaveDrawing(drawing);
        }

        private void toolStripButtonSaveAs_Click(object sender, EventArgs e)
        {
            Drawing drawing = GetCurrentDrawing();
            SaveDrawingAs(drawing);
        }

        private void SaveDrawing(Drawing drawing)
        {
            VectorPanel vectorPanel = GetCurrentVectorPanel();

            if (vectorPanel != null && String.IsNullOrEmpty(vectorPanel.DrawingPath))
            {
                SaveDrawingAs(drawing);
            }
            else
            {
                if (vectorPanel != null && drawing != null)
                {
                    drawing.IsDirty = false;
                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Drawing));
                    System.IO.FileStream file = System.IO.File.Create(System.IO.Path.Combine(vectorPanel.DrawingPath, drawing.FileName));
                    writer.Serialize(file, drawing);
                    file.Close();
                }
            }
        }

        private void SaveDrawingAs(Drawing drawing)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Atari Vector Drawing | *.avd";

            DialogResult dr = sd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //save the filename into the actual file
                drawing.FileName = Path.GetFileName(sd.FileName);
                drawing.IsDirty = false;
                GetCurrentVectorPanel().DrawingPath = System.IO.Path.GetDirectoryName(sd.FileName);
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Drawing));
                System.IO.FileStream file = System.IO.File.Create(sd.FileName);
                writer.Serialize(file, drawing);
                file.Close();
            }
        }

        private void toolStripButtonExportBinary_Click(object sender, EventArgs e)
        {
            BinaryExportDialog bd = new BinaryExportDialog();
            List<Drawing> allDrawings = new List<Drawing>();
            foreach (TabPage page in tabControlImages.TabPages)
            {
                VectorPanel vp = page.Tag as VectorPanel;
                allDrawings.Add(vp.Drawing);
            }
            bd.SetDrawing(GetCurrentDrawing(), allDrawings);
            bd.UpdateSource();
            bd.ShowDialog();
        }

        #region TabControl Events
        private void tabControlImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            VectorPanel vectorPanel = GetCurrentVectorPanel();
            VectorToolController.VectorPanel = vectorPanel;
            if (vectorPanel != null)
            {
                vectorPanel.SetZoom(Globals.zoomLevel);
            }
            ReloadDrawing();
        }

        private void tabControlImages_DrawItem(object sender, DrawItemEventArgs e)
        {
            Bitmap closeIcon = Properties.Resources.file_close;
            e.Graphics.DrawImage(closeIcon, new Point(e.Bounds.Right - 14, e.Bounds.Top + 6));
            
            //get the filename and dirty status 
            VectorPanel vectorPanel = this.tabControlImages.TabPages[e.Index].Tag as VectorPanel;
            Drawing drawing = vectorPanel?.Drawing;
            if (e.Index == tabControlImages.SelectedIndex)
            {        
                e.Graphics.FillRectangle(Brushes.Goldenrod, new Rectangle(e.Bounds.Left + 3, e.Bounds.Height-3, e.Bounds.Width-4,3));
                Font boldFont = new Font(e.Font, FontStyle.Bold);
                e.Graphics.DrawString(drawing.GetFilenameTitle(), boldFont, Brushes.Black, e.Bounds.Left + 2, e.Bounds.Top + 4);
            }
            else
            {
                e.Graphics.DrawString(drawing.GetFilenameTitle(), e.Font, Brushes.Black, e.Bounds.Left + 4, e.Bounds.Top + 4);
            }
        }

        private void tabControlImages_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabControlImages.TabPages.Count; i++)
            {
                Rectangle r = tabControlImages.GetTabRect(i);
                //Getting the position of the close button
                Rectangle closeButton = new Rectangle(r.Right - 12, r.Top, 12, 12);
                if (closeButton.Contains(e.Location))
                {
                    //hit on close, see if drawing is saved or if user needs prompted
                    VectorPanel vp = tabControlImages.TabPages[i].Tag as VectorPanel;
                    if (vp.Drawing.IsDirty)
                    {
                        DialogResult dr = MessageBox.Show("This image is not saved, would you like to save it before closing?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            SaveDrawing(vp.Drawing);
                            break;
                        }
                    }
                    this.tabControlImages.TabPages.RemoveAt(i);
                    //can only hit one... so exit this now
                    break;
                }
            }
        }

        #endregion


        private void listViewVectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            Drawing drawing = GetCurrentDrawing();
            if (drawing != null)
            {
                drawing.ClearAllSelections();
                foreach (ListViewItem item in listViewVectors.SelectedItems)
                {
                    Vector vItem = item.Tag as Vector;
                    if (vItem != null)
                    {
                        vItem.Start.Selected = true;
                        vItem.End.Selected = true;
                    }
                }
                VectorPanel vp = GetCurrentVectorPanel();
                if (vp != null)
                {
                    vp.Refresh();
                    vp.Invalidate();
                }
                //ReloadDrawing();
            }
        }

        private void listViewVectors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //delete the selected vectors
                foreach (ListViewItem item in listViewVectors.SelectedItems)
                {
                    Drawing drawing = GetCurrentDrawing();
                    if (drawing != null)
                    {
                        Vector v = item.Tag as Vector;
                        if (v != null)
                        {
                            drawing.Vectors.Remove(v);
                        }
                        
                    }
                }
            }
        }

        private void listViewVectors_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void ReloadDrawing()
        {
            VectorPanel vp = GetCurrentVectorPanel();
            if (vp != null)
            {
                vp.RedrawControl();
            }
            LoadVectors(vp.Drawing);
        }

        private void toolStripButtonCombineVectors_Click(object sender, EventArgs e)
        {
            
            List<Guid> vectorsToMerge = listViewVectors.SelectedItems.Cast<ListViewItem>().Select(i => i.Tag).OfType<Vector>().Select(i => i.Id).ToList();
            if (vectorsToMerge.Count != 2)
            {
                MessageBox.Show("You must select exactly two vectors to merge.");
            }
            else
            {
                Drawing drawing = GetCurrentDrawing();
                if (drawing != null)
                {
                    Vector v1 = drawing.Vectors.Where(v => v.Id == vectorsToMerge[0]).FirstOrDefault();
                    Vector v2 = drawing.Vectors.Where(v => v.Id == vectorsToMerge[1]).FirstOrDefault();

                    VectorPanel vectorPanel = GetCurrentVectorPanel();
                    if (vectorPanel != null)
                    {
                        int vectorIndex = drawing.Vectors.IndexOf(v1);
                        Vector mergedVector = VectorUtility.MergeVectors(v1, v2);
                        drawing.Vectors.Remove(v1);
                        drawing.Vectors.Remove(v2);
                        drawing.Vectors.Insert(vectorIndex, mergedVector);
                    }
                    ReloadDrawing();
                }
            }
        }

        private void toolStripButtonImport_Click(object sender, EventArgs e)
        {
            VectorPanel currentPanel = GetCurrentVectorPanel();
            if (currentPanel != null)
            {
                if (currentPanel.Drawing.Vectors.Count > 0)
                {
                    DialogResult drExisting = MessageBox.Show("This drawing already has vectors, would you like to delete them?", "Remove Existing Vectors", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (drExisting == DialogResult.Cancel)
                    {
                        return;
                    }
                    if (drExisting == DialogResult.Yes)
                    {
                        currentPanel.Drawing.Vectors.Clear();
                    }
                }
                ImportDialog id = new ImportDialog();
                id.VectorColor = GetSelectedColor();
                id.StartPoint = new Point(0, 0);
                id.Transform = VectorTransform.FlipY;
                DialogResult dr = id.ShowDialog();
                VectorPanel vp = GetCurrentVectorPanel();
                if (vp != null)
                {
                    if (dr == DialogResult.OK)
                    {
                        vp.CreateVectors(id.Vectors);
                        vp.RedrawControl();
                    }
                }
            }
            else
            {
                MessageBox.Show("You must have a drawing open in order to import.");
            }
        }

        private void ToolStripButtonPointer_Click(object sender, EventArgs e)
        {
            ApplyToolStripRadioEffect(sender);
            SetCurrentTool(VectorTool.Selecting);
        }

        private void ToolStripButtonCrosshair_Click(object sender, EventArgs e)
        {
            ApplyToolStripRadioEffect(sender);
            SetCurrentTool(VectorTool.Drawing);
        }

        private void toolStripButtonScissors_Click(object sender, EventArgs e)
        {
            ApplyToolStripRadioEffect(sender);
            SetCurrentTool(VectorTool.Scissors);
        }

        private void toolStripButtonCircleTool_Click(object sender, EventArgs e)
        {
            ApplyToolStripRadioEffect(sender);
            SetCurrentTool(VectorTool.Ellipse);
        }

        private void SetCurrentTool(VectorTool vectorTool)
        {
            //_currentPaletteTool = vectorTool;
            //foreach(TabPage page in tabControlImages.TabPages)
            //{
            //    VectorPanel panel = page.Tag as VectorPanel;
            //    if (panel != null)
            //    {
            //        panel.SetCurrentTool(_currentPaletteTool);
            //    }
            //}
            //show the proper tool properties
            tabControlToolProperties.TabPages.Clear();
            switch (vectorTool)
            {
                case VectorTool.Selecting:
                    tabControlToolProperties.TabPages.Add(tabPageSelect);
                    break;
                case VectorTool.Drawing:
                    tabControlToolProperties.TabPages.Add(tabPageEdit);
                    break;
                case VectorTool.Scissors:
                    tabControlToolProperties.TabPages.Add(tabPageScissor);
                    break;
                case VectorTool.Ellipse:
                    tabControlToolProperties.TabPages.Add(tabPageDrawEllipse);
                    break;
            }
            VectorToolController.CurrentVectorTool = vectorTool;
        }

        private void ApplyToolStripRadioEffect(object sender)
        {
            foreach (ToolStripButton button in toolStripTools.Items.OfType<ToolStripButton>())
            {
                if (button == sender) button.Checked = true;
                if ((button != null) && (button != sender))
                {
                    button.Checked = false;
                }
            }
        }

        private void toolStripButton_SaveToSVG_Click(object sender, EventArgs e)
        {
            Drawing drawing = GetCurrentDrawing();
            string svg = drawing.GetSVG();

            SaveFileDialog sd = new SaveFileDialog();
            DialogResult dr = sd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(sd.FileName, svg);
            }
        }

        private void toolStripButtonVectorDelete_Click(object sender, EventArgs e)
        {
            List<Vector> vectors = new List<Vector>();
            listViewVectors.BeginUpdate();
            List<ListViewItem> itemsToRemove = new List<ListViewItem>();
            foreach (ListViewItem item in listViewVectors.SelectedItems)
            {
                vectors.Add(item.Tag as Vector);
                itemsToRemove.Add(item);
            }
            foreach (ListViewItem item in itemsToRemove)
            {
                listViewVectors.Items.Remove(item);
            }
            listViewVectors.EndUpdate();
            GetCurrentVectorPanel()?.DeleteVectors(vectors);
        }

        private void toolStripButtonShowHideGrid_Click(object sender, EventArgs e)
        {
            var v = GetCurrentVectorPanel();
            if (v != null)
            {
                v.ShowGrid = toolStripButtonShowHideGrid.Checked;
                v.Invalidate();
            }
        }

        private void toolStripButtonShowHideVectors_Click(object sender, EventArgs e)
        {
            var v = GetCurrentVectorPanel();
            if (v != null)
            {
                v.ShowHiddenVectors = toolStripButtonShowHideVectors.Checked;
                v.Invalidate();
            }
            
        }

        #region Form Events
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            GetCurrentVectorPanel()?.KeyDown(sender, e);
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            GetCurrentVectorPanel()?.KeyPress(sender, e);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            GetCurrentVectorPanel()?.KeyUp(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabControlImages.TabPages.Count > 0)
            {
                TabPage currentPage = tabControlImages.SelectedTab;
                if (currentPage != null)
                {
                    VectorPanel vp = currentPage.Tag as VectorPanel;
                    if (vp.Drawing.IsDirty)
                    {
                        DialogResult dr = MessageBox.Show("The drawing '" + currentPage.Text + "' has not been saved. Do you want to save it before closing?", "Save file?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                            return;
                        }
                        else if (dr == DialogResult.Yes)
                        {
                            SaveDrawing(vp.Drawing);
                        }
                    }
                }
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            GetCurrentVectorPanel()?.Resize();
        }

        #endregion

        private void toolStripButtonMergePoints_Click(object sender, EventArgs e)
        {
            MergePointsDialog md = new MergePointsDialog();
            md.VectorPanel = GetCurrentVectorPanel();
            DialogResult dr = md.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //actually do the merging now
                md.VectorPanel.MergePoints(md.MergeTolerance, false, false);
            }
            md.Close();
        }

        private void toolStripButtonVisibility_Click(object sender, EventArgs e)
        {
            foreach(Vector v in listViewVectors.SelectedItems.Cast<ListViewItem>().Select(i => (Vector)i.Tag))
            {
                if (v.Brightness > 0){
                    v.Brightness = 0;
                    v.ColorIndex = 0;
                }
                else
                {
                    v.Brightness = 16;
                    v.ColorIndex = VectorColorController.GetColorIndex(GetSelectedColor());
                }
            }
            LoadVectors(GetCurrentDrawing());
        }

        private void toolStripButtonConnect_Click(object sender, EventArgs e)
        {
            Drawing drawing = GetCurrentDrawing();
            //work backwards so we can insert without affecting the current iteration
            for(int i = drawing.Vectors.Count -2; i >= 0; i--)
            {
                Vector currentVector = drawing.Vectors[i];
                Vector connectingVector = drawing.Vectors[i + 1];
                if (!currentVector.End.Point.Matches(connectingVector.Start.Point))
                {
                    //end of current does not match the start of the next vector
                    //insert a new one.
                    Vector newVector = new Vector(currentVector.End.Point, connectingVector.Start.Point);
                    drawing.Vectors.Insert(i + 1, newVector);
                }
            }
            LoadVectors(drawing);
        }

        private void toolStripButtonOptimizeVectors_Click(object sender, EventArgs e)
        {
            Drawing drawing = GetCurrentDrawing();
            //work backwards so we can blend without affecting the current iteration
            for (int i = drawing.Vectors.Count - 2; i >= 0; i--)
            {
                Vector currentVector = drawing.Vectors[i];
                Vector connectingVector = drawing.Vectors[i + 1];
                if (currentVector.ColorIndex == 0 && connectingVector.ColorIndex == 0)
                {
                    //these are both hidden, the second can be removed
                    currentVector.End.Point = connectingVector.End.Point;
                    currentVector.End.Selected = connectingVector.End.Selected;
                    drawing.Vectors.Remove(connectingVector);
                }
            }
            LoadVectors(drawing);
        }

        private void toolStripButtonSplitVector_Click(object sender, EventArgs e)
        {
            Drawing drawing = GetCurrentDrawing();
            for(int i = drawing.Vectors.Count-1; i >= 0; i--)
            {
                Vector vector = drawing.Vectors[i];
                if (vector.Start.Selected && vector.End.Selected)
                {
                    //split the vector...
                    Point midPoint = new Point((vector.End.Point.X + vector.Start.Point.X)/2, (vector.End.Point.Y + vector.Start.Point.Y)/2);
                    Vector newVector = new Vector(new VectorPoint() { Id = Guid.NewGuid(), Point = midPoint, Selected = true }, vector.End, vector.ColorIndex);
                    vector.End.Point = midPoint;
                    drawing.Vectors.Insert(i + 1, newVector);
                }
            }
            ReloadDrawing();
            LoadVectors(drawing);
        }

        private void toolStripButtonPlay_Click(object sender, EventArgs e)
        {
            timerAnimate.Enabled = toolStripButtonPlay.Checked;
        }

        private void timerAnimate_Tick(object sender, EventArgs e)
        {
            int index = tabControlImages.SelectedIndex;
            index++;
            if (index >= tabControlImages.TabCount)
            {
                index = 0;
            }
            tabControlImages.SelectedIndex = index;
            VectorPanel vectorPanel = GetCurrentVectorPanel();
            VectorToolController.VectorPanel = vectorPanel;
            vectorPanel.SetZoom(Globals.zoomLevel);
            ReloadDrawing();
        }

        private void numericUpDownEllipseVertices_ValueChanged(object sender, EventArgs e)
        {
            VectorToolSettings.EllipseVertexCount = (int)numericUpDownEllipseVertices.Value;
        }

    }
}
