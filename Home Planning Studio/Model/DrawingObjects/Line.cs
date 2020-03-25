using Home_Planning_Studio.Model.DrawingObjects.Interfaces;
using Home_Planning_Studio.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Media;

namespace Home_Planning_Studio.Model.DrawingObjects
{
    public class Line : IObject
    {
        private IList<PointF> _points;
        
        public bool IsChecked { get; set; }
        public Guid Id { get; }
        public PointF StartPoint { get { return _points.FirstOrDefault(); } }
        public PointF EndPoint { get { return _points.LastOrDefault(); } }
        public PointF BasePoint { get; set; }
        public string Name { get => "Отрезок";
        }
        public Line(IList<PointF> points)
        {
            _points = new List<PointF>(points);
            Id = Guid.NewGuid();
            IsChecked = false;
            BasePoint = new PointF((StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2);
        }
               

        public void Draw(Graphics g, float scale, PointF startPoint)
        {
            System.Drawing.Color color;
            if (IsChecked) color = System.Drawing.Color.Blue;
            else color = System.Drawing.Color.Black;

            using (System.Drawing.Pen pen = new System.Drawing.Pen(color, 2F))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawLine(pen, new PointF(StartPoint.X * scale + startPoint.X,
                                              startPoint.Y - StartPoint.Y * scale),
                                new PointF(EndPoint.X * scale + startPoint.X,
                                          startPoint.Y - EndPoint.Y * scale));
                
                if (IsChecked)
                {
                    var tempSP = new PointF(StartPoint.X * scale + startPoint.X,
                                                startPoint.Y - StartPoint.Y * scale);
                    var tempEP = new PointF(EndPoint.X * scale + startPoint.X,
                                                startPoint.Y - EndPoint.Y * scale);
                    var tempBP = new PointF(BasePoint.X * scale + startPoint.X,
                                                startPoint.Y - BasePoint.Y * scale);

                    g.FillRectangle(System.Drawing.Brushes.DarkBlue, new RectangleF(tempSP.X - 5F, tempSP.Y - 5F, 10F, 10F));
                    g.FillRectangle(System.Drawing.Brushes.DarkBlue, new RectangleF(tempEP.X - 5F, tempEP.Y - 5F, 10F, 10F));

                    g.FillEllipse(System.Drawing.Brushes.DarkBlue, new RectangleF(tempBP.X - 5F, tempBP.Y - 5F, 10F, 10F));
                }
            }
        }

        public bool Contains(PointF point, float scale, PointF startPoint)
        {
            var polyStartPointF = Vector.GetReplacedSubVectorEndPoint(StartPoint, EndPoint, StartPoint, 3);
            var polyEndPointF = Vector.GetReplacedSubVectorEndPoint(StartPoint, EndPoint, EndPoint, 3);

            var polyLeftStartPointF = Vector.GetRotatedPoint(-90, StartPoint, polyStartPointF);
            var polyLeftEndPointF = Vector.GetRotatedPoint(-90, EndPoint, polyEndPointF);
            var polyRightEndPointF = Vector.GetRotatedPoint(90, EndPoint, polyEndPointF);
            var polyRightStartPointF = Vector.GetRotatedPoint(90, StartPoint, polyStartPointF);
                        
            var p = new System.Windows.Point(point.X, point.Y);

            return IsPointInPolygon4(new PointF[] { polyLeftStartPointF, polyLeftEndPointF, polyRightEndPointF, polyRightStartPointF }, point);
        }
        
        public static bool IsPointInPolygon4(PointF[] polygon, PointF testPoint)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public void ChangeCheckedFlag()
        {
            IsChecked = !IsChecked;
        }
    }
}
