using Home_Planning_Studio.Model.Commands.Interfaces;
using Home_Planning_Studio.Model.DrawingObjects;
using Home_Planning_Studio.Model.DrawingObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home_Planning_Studio.Model.Commands
{
    public class CreateObjectCommand : ICommand
    {
        private Objects _objects;
        private IObject _object;

        public CreateObjectCommand(Objects objs, IObject obj)
        {
            _objects = objs;
            _object = obj;
        }
                    
        public string Name
        {
            get { return $"Создать: {_object.Name}"; }
        }

        public void Execute()
        {
            _objects.Add(_object);
            _objects.OnChanged();
        }

        public void Cancel()
        {
            _objects.RemoveLastObj();
            _objects.OnChanged();
        }        
    }
}
