using Home_Planning_Studio.Model;
using Home_Planning_Studio.Model.Commands;
using Home_Planning_Studio.Model.DrawingObjects;
using Home_Planning_Studio.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Home_Planning_Studio
{
    public partial class MainForm : Form
    {
        private ProgramManager pm;
        public MainForm()
        {
            InitializeComponent();
            pm = new ProgramManager(this, panel2);
            pm.ManagerChanged += manager_Changed;
            Subscribe();
            BuildInterface();
        }

        public void Subscribe()
        {
            pm.CommandManager.StateChanged += manager_StateChanged;
        }

        private void manager_StateChanged(object sender, EventArgs e)
        {
            BuildInterface();
        }

        private void manager_Changed(object sender, EventArgs e)
        {
            BuildInterface();
        }

        public void BuildInterface()
        {
            btRedo.Enabled = pm.CommandManager.CanRedo;
            btUndo.Enabled = pm.CommandManager.CanUndo;

            btRedo.DropDownItems.Clear();
            btRedo.DropDownItems.AddRange(pm.CommandManager.RedoItems.Select(c => new ToolStripMenuItem(c)).ToArray());
            btUndo.DropDownItems.Clear();
            btUndo.DropDownItems.AddRange(pm.CommandManager.UndoItems.Select(c => new ToolStripMenuItem(c)).ToArray());
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            pm.CreateDrawing();
        }

        private void btLine_Click_1(object sender, EventArgs e)
        {
            var page = pm.View.SelectedTab as DwgPanel;
            if (page != null)
                page.SetToolType(ToolType.Line);
        }

        private void btPolyLine_Click_1(object sender, EventArgs e)
        {
            var page = pm.View.SelectedTab as DwgPanel;
            if (page != null)
                page.SetToolType(ToolType.Polyline);
        }

        private void btCircle_ButtonClick(object sender, EventArgs e)
        {
            var page = pm.View.SelectedTab as DwgPanel;
            if (page != null)
                page.SetToolType(ToolType.Circle);
        }

        private void btArc_ButtonClick(object sender, EventArgs e)
        {
            var page = pm.View.SelectedTab as DwgPanel;
            if (page != null)
                page.SetToolType(ToolType.Arc);
        }

        private void miCreate_Click(object sender, EventArgs e)
        {
            pm.CreateDrawing();
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            pm.LoadDrawing();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            pm.SaveDrawing();
        }

        private void btSaveAs_Click(object sender, EventArgs e)
        {

        }

        private void btUndo_ButtonClick(object sender, EventArgs e)
        {
            pm.CommandManager.Undo();
        }

        private void btRedo_ButtonClick(object sender, EventArgs e)
        {
            pm.CommandManager.Redo();
        }

        private void miUndo_Click(object sender, EventArgs e)
        {
            pm.CommandManager.Undo();
        }

        private void miRedo_Click(object sender, EventArgs e)
        {
            pm.CommandManager.Redo();
        }

        private void btUndo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var index = btUndo.DropDownItems.IndexOf(e.ClickedItem);
            pm.CommandManager.Undo(index + 1);
        }

        private void btRedo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var index = btRedo.DropDownItems.IndexOf(e.ClickedItem);
            pm.CommandManager.Redo(index + 1);
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Левцун Д.К., \nКИУКИ-16-5", "Author",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        
    }
}
