using System;
using System.Collections.Generic;
using System.Text;

namespace TextCommand {
    class Invoker {
        ICommand command;

        public Invoker() { }

        public void SetCommand(ICommand command) {
            this.command = command;
        }

        public void NextCommand() {
            command.Execute();
        }

        public void UndoCommand() {
            command.Undo();
        }

        public void RedoCommand() {
            command.Redo();
        }
    }
}
