using System;
using System.Collections.Generic;
using System.Text;

namespace TextCommand {
    class Client {
        private List<ICommand> history;
        private Invoker invoker;
        private Receiver receiver;
        private Parser parser;

        private int indexCurrentCommand = -1;

        public bool CanUndo {
            get {
                return indexCurrentCommand >= 0;
            }
        }

        public bool CanRedo {
            get {
                Console.WriteLine(indexCurrentCommand);
                return history.Count > 0 && indexCurrentCommand < history.Count - 1;
            }
        }

        public Client(string str, string pathToFile) {
            invoker = new Invoker();
            receiver = new Receiver(str);
            parser = new Parser(pathToFile, receiver);
            history = new List<ICommand>();
        }

        public void ExecuteAllCommand() {
            ICommand command = null;

            do {
                command = parser.GetCommand();
                if (command == null) break;

                invoker.SetCommand(command);

                if (command as CommandRedo != null) {
                    Redo();
                    continue;
                }

                if (command as CommandUndo != null) {
                    Undo();
                    continue;
                }

                AddHistory(command);
                invoker.NextCommand();
            } while (command != null);

            receiver.ShowStr();
        }

        protected void AddHistory(ICommand command) {
            CutHistory();
            history.Add(command);
            indexCurrentCommand++;
        }

        protected void CutHistory() {
            int index = indexCurrentCommand + 1;
            if (index < history.Count) {
                history.RemoveRange(index, history.Count - index);
            }
        }

        protected void Redo() {
            if (!CanRedo)
                return;
            indexCurrentCommand++;
            invoker.SetCommand(history[indexCurrentCommand]);
            invoker.RedoCommand();
        }

        protected void Undo() {
            if (!CanUndo)
                return;
            invoker.SetCommand(history[indexCurrentCommand]);
            invoker.UndoCommand();
            indexCurrentCommand--;
        }
    }
}
