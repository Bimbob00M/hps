using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Home_Planning_Studio.Model.DrawingObjects.Interfaces
{
    public interface IObject
    {
        string Name { get; }
        Guid Id { get; }
        bool IsChecked { get; set; }
        void Draw(Graphics g, float scale, PointF startPoint);
        bool Contains(PointF point, float scale, PointF startPoint);
        void ChangeCheckedFlag();
    }
}
