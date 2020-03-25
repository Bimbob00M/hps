using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Home_Planning_Studio.Model.Grid
{
    [Serializable]
    public class Grid
    {
        public event EventHandler Changed;

        private const float _scaleStep = 1.2F;
        private float _gridScale;
        private float _gridPow;
        private PointF _startPoint;
        private PointF _offsetPoint;
        
        public PointF PrevMousePosition { get; set; }
        public PointF CurrMousePosition { get; set; }

        public float Scale { get { return _gridScale; } }
        public PointF StartPoint { get { return _startPoint; } }

        public Grid(PointF sp)
        {
            _startPoint = sp;
            _gridScale = 1F;
            _gridPow = 1F;
        }

        public Grid(PointF sp, float gs, float gp)
        {
            _startPoint = sp;
            _gridScale = gs;
            _gridPow = gp;
        }

        public virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }

        public void DrawGrid(Graphics g, Size clientSize)
        {
            Pen Spen = new Pen(Color.LightGray);
            Pen Bpen = new Pen(Color.Gray);

            var gp = _gridPow;
            var gs = _gridScale;
            var sp = _startPoint;

            var frequency = ((250f * _gridScale) / (float)Math.Pow(5f, _gridPow));
            float i;

            for (i = _startPoint.X; i > 0;)
            {
                g.DrawLine(Bpen, i, 0, i, clientSize.Height);
                i -= frequency / 5f;
                for (int j = 0; j < 4; j++, i -= frequency / 5f)
                {
                    g.DrawLine(Spen, i, 0, i, clientSize.Height);
                }
            }

            for (i = _startPoint.X; i < clientSize.Width;)
            {
                g.DrawLine(Bpen, i, 0, i, clientSize.Height);
                i += frequency / 5f;
                for (int j = 0; j < 4; j++, i += frequency / 5f)
                {
                    g.DrawLine(Spen, i, 0, i, clientSize.Height);
                }
            }

            for (i = _startPoint.Y; i < clientSize.Height;)
            {
                g.DrawLine(Bpen, 0, i, clientSize.Width, i);
                i += frequency / 5f;
                for (int j = 0; j < 4; j++, i += frequency / 5f)
                {
                    g.DrawLine(Spen, 0, i, clientSize.Width, i);
                }
            }

            for (i = _startPoint.Y; i > 0;)
            {
                g.DrawLine(Bpen, 0, i, clientSize.Width, i);
                i -= frequency / 5f;
                for (int j = 0; j < 4; j++, i -= frequency / 5f)
                {
                    g.DrawLine(Spen, 0, i, clientSize.Width, i);
                }
            }
            Spen.Dispose();
            Bpen.Dispose();

            g.DrawLine(new Pen(Brushes.Green, 2), _startPoint, new PointF(_startPoint.X, 0));
            g.DrawLine(new Pen(Brushes.Red, 2), _startPoint, new PointF(clientSize.Width, _startPoint.Y));
            g.DrawArc(new Pen(Brushes.Green, 2), new RectangleF(_startPoint.X - 14, _startPoint.Y - 15, 30, 30), 135, 182);
            g.DrawArc(new Pen(Brushes.Red, 2), new RectangleF(_startPoint.X - 14, _startPoint.Y - 15, 30, 30), -45, 180);
        }

        public void ZoomIn(Point mouseLocation)
        {
            var BeforeOffsetPoint = new PointF(((float)mouseLocation.X - _startPoint.X) * _gridScale, 
                                                (_startPoint.Y - (float)mouseLocation.Y) * _gridScale);

            if (_gridScale * _scaleStep < Math.Pow(_scaleStep, 25)) _gridScale *= _scaleStep;

            if ((250f * _gridScale / Math.Pow(5, _gridPow)) > 250f) _gridPow++;

            var AfterOffsetPoint = new PointF(((float)mouseLocation.X - _startPoint.X) * _gridScale,
                                            (_startPoint.Y - (float)mouseLocation.Y) * _gridScale);

            var OffsetWidth = Math.Abs(BeforeOffsetPoint.X - AfterOffsetPoint.X) / (_gridScale / _scaleStep);
            var OffsetHeight = Math.Abs(BeforeOffsetPoint.Y - AfterOffsetPoint.Y) / (_gridScale / _scaleStep);

            if (mouseLocation.X > _startPoint.X) _startPoint.X -= OffsetWidth;
            else _startPoint.X += OffsetWidth;

            if (mouseLocation.Y > _startPoint.Y) _startPoint.Y -= OffsetHeight;
            else _startPoint.Y += OffsetHeight;

            OnChanged();
        }
        
        public void ZoomOut(Point mouseLocation)
        {
            var BeforeOffsetPoint = new PointF(((float)mouseLocation.X - _startPoint.X) * _gridScale,
                                                (_startPoint.Y - (float)mouseLocation.Y) * _gridScale);

            if (_gridScale > 0.0001f) _gridScale /= _scaleStep;

            if ((250f * _gridScale / Math.Pow(5, _gridPow)) < 50f) _gridPow--;

            var AfterOffsetPoint = new PointF(((float)mouseLocation.X - _startPoint.X) * _gridScale,
                                                (_startPoint.Y - (float)mouseLocation.Y) * _gridScale);

            var OffsetWidth = Math.Abs(BeforeOffsetPoint.X - AfterOffsetPoint.X) / (_gridScale * _scaleStep);
            var OffsetHeight = Math.Abs(BeforeOffsetPoint.Y - AfterOffsetPoint.Y) / (_gridScale * _scaleStep);

            if (mouseLocation.X > _startPoint.X) _startPoint.X += OffsetWidth;
            else _startPoint.X -= OffsetWidth;

            if (mouseLocation.Y > _startPoint.Y) _startPoint.Y += OffsetHeight;
            else _startPoint.Y -= OffsetHeight;

            OnChanged();
        }
        
        public void ReplaceViewPoint()
        {
            if (CurrMousePosition.X > PrevMousePosition.X) _startPoint.X = _offsetPoint.X + Math.Abs(CurrMousePosition.X - PrevMousePosition.X);
            else _startPoint.X = _offsetPoint.X - Math.Abs(CurrMousePosition.X - PrevMousePosition.X);

            if (CurrMousePosition.Y > PrevMousePosition.Y) _startPoint.Y = _offsetPoint.Y + Math.Abs(CurrMousePosition.Y - PrevMousePosition.Y);
            else _startPoint.Y = _offsetPoint.Y - Math.Abs(CurrMousePosition.Y - PrevMousePosition.Y);

            OnChanged();
        }

        public void SetOffsetPoint()
        {
            _offsetPoint = _startPoint;
        }
    }    
}

