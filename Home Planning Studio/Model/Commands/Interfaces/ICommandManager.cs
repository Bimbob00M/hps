using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home_Planning_Studio.Model.Commands.Interfaces
{
    public interface ICommandManager
    {
        void Execute(ICommand command);
    }
}
