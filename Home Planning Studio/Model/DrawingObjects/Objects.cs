using Home_Planning_Studio.Model.DrawingObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Home_Planning_Studio.Model.DrawingObjects
{
    public class Objects : IEnumerable<IObject>
    {
        public event EventHandler Changed;

        private List<IObject> _objects = new List<IObject>();
        

        public virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }

        public void DrawObjects(Graphics g, float scale, PointF startPoint)
        {
            foreach (var obj in _objects)
            {
                obj.Draw(g, scale, startPoint);
            }
        }

        public void Add(IObject obj)
        {
            _objects.Add(obj);
        }

        public void AddRange(List<IObject> objs)
        {
            _objects.AddRange(objs);
        }

        public IObject Find(IObject obj)
        {
            return _objects.Find(o => o.Id == obj.Id);
        }

        public void Remove(IObject obj)
        {
            _objects.Remove(obj);
        }

        internal void RemoveLastObj()
        {
            if (_objects.Count != 0)
                _objects.RemoveAt(_objects.Count - 1);
        }

        public IObject LastObj
        {
            get { return _objects.Count == 0 ? null : _objects[_objects.Count - 1]; }
        }

        public int Count
        {
            get { return _objects.Count; }
        }

        public IObject this[int index]
        {
            get { return _objects[index]; }
        }

        public IEnumerator<IObject> GetEnumerator()
        {
            return _objects.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
