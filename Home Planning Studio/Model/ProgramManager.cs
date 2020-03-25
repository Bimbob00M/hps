using Home_Planning_Studio.Model.Commands;
using Home_Planning_Studio.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Home_Planning_Studio.Model
{
    public class ProgramManager
    {
        public event EventHandler ManagerChanged;

        private int _drawingIndex;
        private Control _parent;
        public DwgTabControl View { get; set; }
        public CommandManager CommandManager { get; set; }
        public Loader Loader { get; }

        public void LoadDrawing()
        {
            var page = Loader.Load();
            if(page != null)
                View.Controls.Add(page);
        }

        public void SaveAsDrawing()
        {
            var page = View.SelectedTab as DwgPanel;
            if (page != null)
            {
                Loader.Save(null, page);
            }

        }

        public void SaveDrawing()
        {
            var page = View.SelectedTab as DwgPanel;
            if (page != null)
            {
                Loader.Save(page.CurrentFileName ,page);
            }

        }

        public ProgramManager(Control Parent, Control ViewParent)
        {
            Loader = new Loader();
            _parent = Parent;
            _drawingIndex = 1;
            View = new DwgTabControl(ViewParent);
            CommandManager = new CommandManager();

            View.TabPageChanged += Build;
        }

        public void CreateDrawing()
        {
            var name = string.Concat("Чертеж ", _drawingIndex);
            _drawingIndex++;
            new DwgPanel(name, View);
        }

        private void Build(object sender, EventArgs e)
        {
            var page = View.SelectedTab as DwgPanel;
            if (page != null)
            {
                CommandManager = page.CommandManager;
                (_parent as MainForm).Subscribe();
                if (ManagerChanged != null)
                    ManagerChanged(this, EventArgs.Empty);
            }
        }
    }
}
