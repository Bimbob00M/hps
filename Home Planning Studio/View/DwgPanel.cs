using Home_Planning_Studio.Model.Commands;
using Home_Planning_Studio.Model.DrawingObjects;
using Home_Planning_Studio.Model.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Home_Planning_Studio.View
{
    [Serializable]
    public class DwgPanel : TabPage
    {
        public bool DataChanged { get; set; }
        public string CurrentFileName { get; set; }

        public CommandManager CommandManager { get; private set; }
        public Objects DrawingObjects { get; private set; }

        private ToolsController _tools;
        private Grid _grid;
        private bool _isMousePressed;

        public DwgPanel(string name, Control parent) : base(name)
        {
            Cursor = Cursors.Cross;
            CommandManager = new CommandManager();
            DrawingObjects = new Objects();
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
            DataChanged = false;

            _tools = new ToolsController(this, DrawingObjects);
            Controls.AddRange(new Control[] {   _tools.tbInput,
                                                _tools.lbFirst,
                                                _tools.lbSecond,
                                                _tools.lbFirstOrSecondPointSet});

            var pWidth = parent.ClientSize.Width;
            var pHeight = parent.ClientSize.Height;
            var StartPoint = new PointF(pWidth - (pWidth - pWidth / 10), pHeight - pHeight / 5);
            _grid = new Grid(StartPoint);

            SetStyle(ControlStyles.AllPaintingInWmPaint
                    | ControlStyles.OptimizedDoubleBuffer
                    | ControlStyles.UserPaint, true);

            BackColor = Color.White;

            DrawingObjects.Changed += UpdatePanel;
            _grid.Changed += UpdatePanel;

            Parent = parent;
        }        
            
        //public DwgPanel(string name, Control parent) : base(name)
        //{
        //    Cursor = Cursors.Cross;
        //    CommandManager = new CommandManager();
        //    DrawingObjects = new Objects();
        //    Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, (byte)(204));
        //    DataChanged = false;

        //    _tools = new ToolsController(this, DrawingObjects);
        //    Controls.AddRange(new Control[] {   _tools.tbInput,
        //                                        _tools.lbFirst,
        //                                        _tools.lbSecond,
        //                                        _tools.lbFirstOrSecondPointSet});

        //    var pWidth = parent.ClientSize.Width;
        //    var pHeight = parent.ClientSize.Height;
        //    var StartPoint = new PointF(pWidth - (pWidth - pWidth / 10), pHeight - pHeight / 5);
        //    _grid = new Grid(StartPoint);

        //    SetStyle(ControlStyles.AllPaintingInWmPaint
        //            | ControlStyles.OptimizedDoubleBuffer
        //            | ControlStyles.UserPaint, true);

        //    BackColor = Color.White;

        //    DrawingObjects.Changed += UpdatePanel;
        //    _grid.Changed += UpdatePanel;

        //    Parent = parent;

        public void SetToolType(ToolType tool)
        {
            _tools.ToolSelect(tool);
        }

        private void UpdatePanel(object sender, EventArgs e)
        {
            DataChanged = true;
            Refresh();
        }

        public void CancelPainting()
        {
            _tools.CancelPaint();
        }

        public void DeleteObjects()
        {
            _tools.DeleteObjects(CommandManager);
        }

        private PointF TransformPoint(PointF p)
        {
            var mouseP = p;
            var startP = _grid.StartPoint;
            var scale = _grid.Scale;
            var resultPoint = new PointF((mouseP.X - startP.X) / scale,
                                (startP.Y - mouseP.Y) / scale);
            return resultPoint;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            _grid.DrawGrid(e.Graphics, ClientSize);
            DrawingObjects.DrawObjects(e.Graphics, _grid.Scale, _grid.StartPoint);

            _tools.OnPaint(e.Graphics);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if(!_tools.IsDrawing)
            {
                if (e.Delta >= 120)
                    _grid.ZoomIn(e.Location);
                else
                    _grid.ZoomOut(e.Location);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                var point = TransformPoint(e.Location);
                _tools.OnMouseClick(point, e.Location, _grid.StartPoint, _grid.Scale, CommandManager);
            }
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            _isMousePressed = true;
            _grid.PrevMousePosition = e.Location;
            if(e.Button == MouseButtons.Right)
            {
                _grid.SetOffsetPoint();
            }            
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            _isMousePressed = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (_isMousePressed)
            {
                if(e.Button == MouseButtons.Right && !_tools.IsDrawing)
                {
                    _grid.CurrMousePosition = e.Location;
                    _grid.ReplaceViewPoint();
                }
            }
            var point = TransformPoint(e.Location);
            _tools.OnMouseMove(point, e.Location);
        }
        
    }
}
