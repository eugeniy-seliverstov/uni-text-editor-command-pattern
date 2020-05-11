using System;
using System.IO;
namespace TextCommand {
    class Parser {
        private StreamReader reader;
        private Receiver receiver;
        string[] commandPars;

        public Parser(string pathToFile, Receiver receiver) {
            reader = new StreamReader(pathToFile);
            this.receiver = receiver;
        }

        ~Parser() {
            reader.Close();
        }

        public ICommand GetCommand() {
            ICommand command = null;

            try {
                commandPars = reader.ReadLine().Split(' ');
            } catch (NullReferenceException exp) {
                return null;
            }

            string typeCommand = commandPars[0];

            switch (typeCommand) {
                case "copy": {
                        command = new CommandCopy(receiver, int.Parse(TrimParam(commandPars[1])), int.Parse(TrimParam(commandPars[2])));
                        break;
                    }
                case "paste": {
                        command = new CommandPaste(receiver, int.Parse(TrimParam(commandPars[1])));
                        break;
                    }
                case "insert": {
                        command = new CommandInsert(receiver, TrimParam(commandPars[1]), int.Parse(TrimParam(commandPars[2])));
                        break;
                    }
                case "delete": {
                        command = new CommandDelete(receiver, int.Parse(TrimParam(commandPars[1])), int.Parse(TrimParam(commandPars[2])));
                        break;
                    }
                case "undo": {
                        command = new CommandUndo();
                        break;
                    }
                case "redo": {
                        command = new CommandRedo();
                        break;
                    }
                default: {
                        command = null;
                        break;
                    }
            }

            return command;
        }

        private string TrimParam(string param) {
            return param.Trim(new char[] { '"', ',' });
        }
    }
}