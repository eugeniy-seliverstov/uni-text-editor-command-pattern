namespace TextCommand {
    class CommandUndo : ICommand {
        ICommand command;

        public CommandUndo() { }

        public void SetCommandUndo(ICommand command) {
            this.command = command;
        }

        public void Execute() {
            command.Undo();
        }

        public void Redo() {
            command.Undo();
        }

        public void Undo() {
            command.Redo();
        }
    }
}
