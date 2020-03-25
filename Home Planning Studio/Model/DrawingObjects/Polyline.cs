using Home_Planning_Studio.Model.DrawingObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Home_Planning_Studio.Model.DrawingObjects
{
    public class Polyline : IObject
    {
        private IList<Line> _lines;
        private bool _isChecked;

        public Guid Id { get; }
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }

        public Polyline()
        {
            Id = Guid.NewGuid();
            _isChecked = false;
            _lines = new List<Line>();
        }

        public void AddLine(Line l)
        {
            _lines.Add(l);
        }

        public string Name
        {
            get { return "Полилиния"; }
        }

        public void Draw(Graphics g, float scale, PointF startPoint)
        {
            foreach(var l in _lines)
            {
                l.Draw(g, scale, startPoint);
            }
        }

        public bool Contains(PointF point, float scale, PointF startPoint)
        {        
            return _lines.Any(l => l.Contains(point, scale, startPoint));
        }

        public void ChangeCheckedFlag()
        {
            IsChecked = !IsChecked;
            for(int i = 0; i < _lines.Count; i++)
            {
                _lines[i].ChangeCheckedFlag();
            }
        }
    }
}
