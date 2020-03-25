using Home_Planning_Studio.Model.Commands.Interfaces;
using Home_Planning_Studio.Model.DrawingObjects;
using Home_Planning_Studio.Model.DrawingObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home_Planning_Studio.Model.Commands
{
    public class SelectObjectCommand : ICommand
    {
        private Objects _objectsStorage;
        private List<IObject> _objects;

        public SelectObjectCommand(Objects storage, List<IObject> objs)
        {
            _objects = new List<IObject>(objs);
            _objectsStorage = storage;
        }

        public string Name
        {
            get
            {
                if (_objects.Count == 1)
                    return $"Выбрать: {_objects.FirstOrDefault().Name}";
                else
                    return $"Выбрать: {_objects.Count} объектов";
            }
        }

        public void Execute()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                _objectsStorage.Find(_objects[i]).ChangeCheckedFlag();
            }
            _objectsStorage.OnChanged();
        }

        public void Cancel()
        {
            Execute();
        }
    }
}
