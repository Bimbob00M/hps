using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Home_Planning_Studio.View
{
    public class DwgTabControl : TabControl
    {
        public event EventHandler TabPageChanged;

        private ContextMenuStrip _cms;
        private int _tabIndex = -1;

        public DwgTabControl(Control parent)
        {
            Parent = parent;
            Size = Parent.Size;
            Dock = DockStyle.Fill;
            SizeMode = TabSizeMode.FillToRight;
            _cms = new ContextMenuStrip();
            _cms.Items.Add("Close tab", null, new EventHandler(OnItemClicked));            
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (TabPageChanged != null)
                TabPageChanged(this, EventArgs.Empty);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);

            if (TabPageChanged != null)
                TabPageChanged(this, EventArgs.Empty);
        }

        private void OnItemClicked(object s, EventArgs e)
        {
            if (_tabIndex != -1)
            {
                TabPages.RemoveAt(_tabIndex);
                _tabIndex = -1;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Right)
            {
                _cms.Show(Cursor.Position);

                for (var i = 0; i < TabCount; ++i)
                    if (GetTabRect(i).Contains(e.Location))
                        _tabIndex = i;
            }
        }

        protected override void OnKeyDown(KeyEventArgs ke)
        {
            base.OnKeyDown(ke);

            if(ke.KeyData == Keys.Escape)
            {
                var currentTabPage = this.SelectedTab as DwgPanel;
                currentTabPage.CancelPainting();
            }
            else if(ke.KeyData == Keys.Delete)
            {
                var currentTabPage = this.SelectedTab as DwgPanel;
                currentTabPage.DeleteObjects();
            }
        }
    }
}
