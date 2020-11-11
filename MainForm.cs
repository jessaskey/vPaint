using System;
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
            NewDrawing();
            //_currentPaletteTool = PaletteTool.Selecting;
            SetCurrentTool(VectorTool.Selecting);
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
                    item.SubItems.Add(v.Color == Color.Transparent ? "Hidden" : "Visible");
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
            return vp?.GetDrawing();
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
                        Drawing d = vp.GetDrawing();
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
            od.Multiselect = false;
            od.CheckFileExists = true;

            DialogResult dr = od.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                LoadDrawing(od.FileName);
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
                EditDrawing(drawing);
                file.Close();
            }
        }

        private void EditDrawing(Drawing drawing)
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
            page.Text = drawing.GetFilename();
            tabControlImages.TabPages.Add(page);
            tabControlImages.SelectedTab = page;

            drawing.OnVectorCollectionChanged = VectorChanged;
            vectorPanel.Resize();
            LoadVectors(drawing);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveDrawing();
        }

        private void SaveDrawing()
        {
            VectorPanel vectorPanel = GetCurrentVectorPanel();
            Drawing drawing = GetCurrentDrawing();

            if (vectorPanel != null && String.IsNullOrEmpty(vectorPanel.DrawingPath))
            {
                

                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "Atari Vector Drawing | *.avd";

                DialogResult dr = sd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {

                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Drawing));
                    System.IO.FileStream file = System.IO.File.Create(sd.FileName);
                    writer.Serialize(file, drawing);
                    file.Close();

                    drawing.IsDirty = false;
                    vectorPanel.DrawingPath = System.IO.Path.GetDirectoryName(sd.FileName);
                }
            }
            else
            {
                if (vectorPanel != null && drawing != null)
                {
                    SaveDrawing(vectorPanel, drawing);
                    drawing.IsDirty = false;
                }
            }
        }

        private void SaveDrawing(VectorPanel vectorPanel, Drawing drawing)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Drawing));
            System.IO.FileStream file = System.IO.File.Create(System.IO.Path.Combine(vectorPanel.DrawingPath,drawing.FileName));
            writer.Serialize(file, drawing);
            file.Close();
        }

        private void toolStripButtonExportBinary_Click(object sender, EventArgs e)
        {
            BinaryExportDialog bd = new BinaryExportDialog();
            bd.Drawing = GetCurrentDrawing();
            bd.UpdateSource();
            bd.ShowDialog();
        }

        private void tabControlImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            VectorToolController.VectorPanel = GetCurrentVectorPanel();
        }

        private void tabControlImages_DrawItem(object sender, DrawItemEventArgs e)
        {
            //This code will render a "x" mark at the end of the Tab caption. 
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 12, e.Bounds.Top + 4);
            //get the filename and dirty status 
            VectorPanel vectorPanel = this.tabControlImages.TabPages[e.Index].Tag as VectorPanel;
            Drawing drawing = vectorPanel?.GetDrawing();
            e.Graphics.DrawString(drawing.GetFilename(), e.Font, Brushes.Black, e.Bounds.Left + 4, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabControlImages_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabControlImages.TabPages.Count; i++)
            {
                Rectangle r = tabControlImages.GetTabRect(i);
                //Getting the position of the "x" mark.
                Rectangle closeButton = new Rectangle(r.Right - 12, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.tabControlImages.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            GetCurrentVectorPanel()?.Resize();
        }

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

        private void toolStripButtonFlipVector_Click(object sender, EventArgs e)
        {
            List<Guid> vectorsToFlip = listViewVectors.SelectedItems.Cast<ListViewItem>().Select(i => i.Tag).OfType<Vector>().Select(i => i.Id).ToList();
            GetCurrentVectorPanel()?.FlipVectors(vectorsToFlip);
            ReloadDrawing();
        }

        private void ReloadDrawing()
        {
            VectorPanel vp = GetCurrentVectorPanel();
            if (vp != null)
            {
                vp.Refresh();
                vp.Invalidate();
            }
            LoadVectors(vp.GetDrawing());
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
                if (currentPanel.GetDrawing().Vectors.Count > 0)
                {
                    DialogResult drExisting = MessageBox.Show("This drawing already has vectors, would you like to delete them?", "Remove Existing Vectors", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (drExisting == DialogResult.Cancel)
                    {
                        return;
                    }
                    if (drExisting == DialogResult.Yes)
                    {
                        currentPanel.GetDrawing().Vectors.Clear();
                    }
                }
                ImportDialog id = new ImportDialog();
                id.VectorColor = GetSelectedColor();
                id.StartPoint = new Point(0, 0); // new Point(currentPanel.Width / 2, currentPanel.Height / 2);
                DialogResult dr = id.ShowDialog();
                VectorPanel vp = GetCurrentVectorPanel();
                if (vp != null)
                {
                    Drawing d = vp.GetDrawing();
                    if (dr == DialogResult.OK)
                    {
                        foreach (Vector v in id.Vectors)
                        {
                            d.Vectors.Add(v);
                        }
                    }
                    vp.RedrawControl();
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
            }
            VectorToolController.CurrentVectorTool = vectorTool;
        }

        private void ApplyToolStripRadioEffect(object sender)
        {
            foreach (ToolStripButton item in ((ToolStripButton)sender).GetCurrentParent().Items)
            {
                if (item == sender) item.Checked = true;
                if ((item != null) && (item != sender))
                {
                    item.Checked = false;
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
            Drawing drawing = GetCurrentDrawing();
            if (drawing != null)
            {
                drawing.ClearAllSelections();
                listViewVectors.BeginUpdate();
                List<ListViewItem> itemsToRemove = new List<ListViewItem>();
                foreach (ListViewItem item in listViewVectors.SelectedItems)
                {
                    Vector vItem = item.Tag as Vector;
                    drawing.Vectors.Remove(vItem);
                    itemsToRemove.Add(item);
                }
                foreach(ListViewItem item in itemsToRemove)
                {
                    listViewVectors.Items.Remove(item);
                }
                listViewVectors.EndUpdate();
                VectorPanel vp = GetCurrentVectorPanel();
                if (vp != null)
                {
                    vp.Refresh();
                    vp.Invalidate();
                }
            }
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

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            GetCurrentVectorPanel()?.KeyDown(sender, e);
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

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
    }
}
