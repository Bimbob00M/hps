using Home_Planning_Studio.Model.Commands;
using Home_Planning_Studio.Model.Commands.Interfaces;
using Home_Planning_Studio.Model.DrawingObjects.Interfaces;
using Home_Planning_Studio.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Home_Planning_Studio.Model.DrawingObjects
{
    public enum ToolType { Select, Line, Polyline, Circle, Arc };

    [Serializable]
    public class ToolsController
    {
        private Control _parent;
        private Objects _objects;
        private List<PointF> _points;
        private IObject _newObject;
        private bool _isCreated;

        public PointF TransformedStartPoint { get; set; }
        public PointF TransformedEndPoint { get; set; }
        public PointF StartPoint { get; set; }
        public PointF EndPoint { get; set; }
        public ToolType ToolType { get; set; }
        public bool IsDrawing { get; private set; }
        public bool IsFirstClick { get; set; }
        public bool IsFirstInput { get; set; }

        public TextBox tbInput;
        public Label lbFirst;
        public Label lbSecond;
        public Label lbFirstOrSecondPointSet;

        public ToolsController(Control parent, Objects obj)
        {
            _parent = parent;
            _objects = obj;
            _points = new List<PointF>();
            _newObject = null;
            _isCreated = false;
            ToolType = ToolType.Select;  
            IsDrawing = false;
            IsFirstClick = true;
            IsFirstInput = true;

            var width = 85;
            tbInput = new TextBox() { Width = width };
            lbFirst = new Label() { AutoSize = true, BackColor = Color.LightGray };
            lbSecond = new Label() { AutoSize = true, BackColor = Color.LightGray };
            lbFirstOrSecondPointSet = new Label() { AutoSize = true, BackColor = Color.LightGray };
            ChangeLabelText();

            HideAllControls();
        }

        public void HideAllControls()
        {
            tbInput.Hide();
            lbFirst.Hide();
            lbSecond.Hide();
            lbFirstOrSecondPointSet.Hide();
        }

        public void ShowCoords()
        {
            lbFirst.Show();
            lbSecond.Show();
            lbFirstOrSecondPointSet.Show();
        }

        public void ShowInput()
        {
            tbInput.Show();
            if (IsFirstInput)
                lbFirst.Hide();
            else
                lbSecond.Hide();
        }

        public void ChangeLabelText()
        {
            if (IsFirstClick)
                lbFirstOrSecondPointSet.Text = "Первая точка: ";
            else
                lbFirstOrSecondPointSet.Text = "Следующая точка: ";
        }

        public void ToolSelect(ToolType toolType)
        {
            ToolType = toolType;
            _newObject = null;
            _points.Clear();
            TransformedStartPoint = new PointF();
            TransformedEndPoint = new PointF();
            StartPoint = new PointF();
            EndPoint = new PointF();
            IsDrawing = false;
            _isCreated = false;
            IsFirstClick = true;
            ChangeLabelText();
            HideAllControls();
            _parent.Invalidate();
        }

        public void CancelPaint()
        {
            ToolSelect(ToolType.Select);
        }

        public void DeleteObjects(ICommandManager manager)
        {
            List<IObject> objForDel = new List<IObject>();
            foreach(var obj in _objects)
            {
                if (obj.IsChecked)
                    objForDel.Add(obj);
            }
            var command =  new DeleteObjectCommand(_objects, objForDel);
            manager.Execute(command);
        }

        public void OnMouseClick(PointF transformedPoint, PointF point, PointF gridStartPoint, float scale, ICommandManager manager)
        {
            TransformedStartPoint = transformedPoint;
            TransformedEndPoint = transformedPoint;
            StartPoint = point;
            EndPoint = point;
            if (IsFirstClick)
            {
                IsFirstClick = false;
                ChangeLabelText();
            }

            ICommand command;

            switch (ToolType)
            {
                case ToolType.Select:
                    for(int i = 0; i < _objects.Count; i++)
                    {
                        var o = _objects[i];
                        if (_objects[i].Contains(TransformedEndPoint, scale, gridStartPoint))
                        {
                            command = new SelectObjectCommand(_objects, new List<IObject>() { _objects[i] });
                            manager.Execute(command);
                        }
                    }
                    break;
                case ToolType.Line:                    
                    IsDrawing = true;
                    _points.Add(transformedPoint);
                    if (_points.Count > 1)
                    {
                        if (_newObject == null)
                            _newObject = new Line(_points);
                        command = new CreateObjectCommand(_objects, _newObject);                          
                        manager.Execute(command);
                        _newObject = null;
                        _points.RemoveAt(0);
                    }
                    break;
                case ToolType.Polyline:
                    IsDrawing = true;
                    _points.Add(transformedPoint);
                    if (_points.Count > 1)
                    {
                        if (_newObject == null)
                            _newObject = new Polyline();
                        if (!_isCreated)
                        {
                            command = new CreateObjectCommand(_objects, _newObject);
                            manager.Execute(command);
                            _isCreated = true;
                        }
                        var newLine = new Line(_points);
                        var polyline = _newObject as Polyline;
                        polyline.AddLine(newLine);
                        _points.RemoveAt(0);
                    }
                    break;
                case ToolType.Circle:
                    break;
                case ToolType.Arc:
                    break;
                default:
                    break;
            }

        }

        public void OnMouseMove(PointF transformedPoint, PointF point)
        {
            TransformedEndPoint = transformedPoint;
            EndPoint = point;
            if (ToolType == ToolType.Line || ToolType == ToolType.Polyline)
            {
                if (lbFirstOrSecondPointSet.Width + lbFirst.Width * 2 + 3 * 10 >= _parent.ClientSize.Width - EndPoint.X)
                    lbFirstOrSecondPointSet.Location = new Point((int)(EndPoint.X - (lbFirstOrSecondPointSet.Width + lbFirst.Width * 2 + 3 * 10)),
                                                                    (int)(EndPoint.Y + 15));
                else
                    lbFirstOrSecondPointSet.Location = new Point((int)(EndPoint.X + 15),
                                                                    (int)(EndPoint.Y + 15));
                if(lbFirstOrSecondPointSet.Height + lbFirstOrSecondPointSet.Location.Y >= _parent.ClientSize.Height)
                    lbFirstOrSecondPointSet.Location = new Point(lbFirstOrSecondPointSet.Location.X,
                                                                    lbFirstOrSecondPointSet.Location.Y - (lbFirstOrSecondPointSet.Height + 15) * 2);
                
                var x = lbFirst.Location = new Point(lbFirstOrSecondPointSet.Location.X + lbFirstOrSecondPointSet.Width + 10,
                                                lbFirstOrSecondPointSet.Location.Y);
                var y = lbSecond.Location = new Point(lbFirst.Location.X + lbFirst.Width + 5,
                                                        lbFirst.Location.Y);

                lbFirst.Text = TransformedEndPoint.X.ToString();
                lbSecond.Text = TransformedEndPoint.Y.ToString();

                ShowCoords();
            }
            _parent.Refresh();     
        }

        public void OnPaint(Graphics g)
        {
            if (IsDrawing)
            {
                switch (ToolType)
                {
                    case ToolType.Select:
                        break;
                    case ToolType.Line:
                        DrawLine(g);
                        break;
                    case ToolType.Polyline:
                        DrawLine(g);
                        break;
                    case ToolType.Circle:
                        break;
                    case ToolType.Arc:
                        break;
                    default:
                        break;
                }
            }
        }

        private void DrawLine(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;

            using (Pen pen = new Pen(Color.Black, 2f))
            {
                g.DrawLine(pen, StartPoint, EndPoint);
                DrawSize(g, 35);
                DrawAngle(g);
            }
        }

        private void DrawSize(Graphics g, float offset)
        {            
            var angle = 0;

            var tempSP = Vector.GetReplacedSubVectorEndPoint(StartPoint, EndPoint, StartPoint, offset);
            var tempEP = Vector.GetReplacedSubVectorEndPoint(StartPoint, EndPoint, EndPoint, offset);

            if (TransformedEndPoint.Y >= TransformedStartPoint.Y) angle = -90;
            else angle = 90;

            tempSP = Vector.GetRotatedPoint(angle, StartPoint, tempSP);
            tempEP = Vector.GetRotatedPoint(angle, EndPoint, tempEP);

            using (Pen pen = new Pen(Color.DimGray, 1.8F))
            {
                pen.DashStyle = DashStyle.Dot;
                g.DrawLine(pen, StartPoint, tempSP);
                g.DrawLine(pen, EndPoint, tempEP);
                g.DrawLine(pen, tempSP, tempEP);
            }
        }

        private void DrawAngle(Graphics g)
        {
            var tempPoint = new PointF(EndPoint.X, StartPoint.Y);
            var firstCathetusLength = (float)Vector.GetVectorLength(StartPoint, tempPoint);
            var secondCathetusLength = (float)Vector.GetVectorLength(EndPoint, tempPoint);
            var hypotenuseLenght = (float)Vector.GetVectorLength(StartPoint, EndPoint);
            
            var replacedSP = new PointF(StartPoint.X + 10, StartPoint.Y);
            replacedSP = Vector.GetReplacedSubVectorEndPoint(StartPoint, replacedSP, StartPoint, hypotenuseLenght);

            var lineLength = (float)Vector.GetVectorLength(StartPoint, replacedSP);

            float angle = 0;
            SizeF size;
            PointF location;
            RectangleF arcRect = new RectangleF();

            if (EndPoint.X >= StartPoint.X)
            {
                size = new SizeF(lineLength * 2, lineLength * 2 + 1);
                location = new PointF(StartPoint.X - lineLength, StartPoint.Y - lineLength);
                arcRect = new RectangleF(location, size);
                angle = (float)(Math.Acos(firstCathetusLength / hypotenuseLenght) * 180 / Math.PI);
                if (EndPoint.Y >= StartPoint.Y)
                {
                    angle *= -1;
                }
            }
            else
            {
                size = new SizeF(lineLength * 2, lineLength * 2 + 1);
                location = new PointF(StartPoint.X - lineLength, StartPoint.Y - lineLength);
                arcRect = new RectangleF(location, size);
                angle = 90 + (float)(Math.Asin(firstCathetusLength / hypotenuseLenght) * 180 / Math.PI);
                if (EndPoint.Y >= StartPoint.Y)
                {
                    angle *= -1;
                }
            }

            using (Pen pen = new Pen(Color.DimGray, 1.8F))
            {
                pen.DashStyle = DashStyle.Dot;

                if (StartPoint != EndPoint)
                    g.DrawArc(pen, arcRect, -angle, angle);
                g.DrawLine(pen, StartPoint, replacedSP);
            }       
        }   
    }
}
