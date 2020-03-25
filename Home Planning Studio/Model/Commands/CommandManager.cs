using Home_Planning_Studio.Model.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home_Planning_Studio.Model.Commands
{
    [Serializable]
    public class CommandManager : ICommandManager
    {
        public event EventHandler StateChanged;

        public bool CanUndo { get { return UndoStack.Count > 0; } }
        public bool CanRedo { get { return RedoStack.Count > 0; } }

        private Stack<ICommand> UndoStack { get; set; }
        private Stack<ICommand> RedoStack { get; set; }

        private void OnStateChange()
        {
            if(StateChanged != null)
                StateChanged(this, EventArgs.Empty);
        }

        public CommandManager()
        {
            UndoStack = new Stack<ICommand>();
            RedoStack = new Stack<ICommand>();
        }

        public void Undo()
        {
            if (UndoStack.Count > 0)
            {
                var command = UndoStack.Pop();
                command.Cancel();
                RedoStack.Push(command);
                OnStateChange();
            }
        }

        public void Redo()
        {
            if (RedoStack.Count > 0)
            {
                var command = RedoStack.Pop();
                command.Execute();
                UndoStack.Push(command);
                OnStateChange();
            }
        }

        public void Execute(ICommand command)
        {
            command.Execute();
            UndoStack.Push(command);
            OnStateChange();
        }

        public IEnumerable<string> UndoItems
        {
            get { return UndoStack.Select(c => c.Name); }
        }

        public IEnumerable<string> RedoItems
        {
            get { return RedoStack.Select(c => c.Name); }
        }

        public void Undo(int count)
        {
            for (int i = 0; i < count; i++)
                Undo();
        }

        public void Redo(int count)
        {
            for (int i = 0; i < count; i++)
                Redo();
        }
    }
}
