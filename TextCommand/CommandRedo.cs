namespace TextCommand {
    class CommandRedo : ICommand {
        ICommand command;

        public CommandRedo() { }

        public void SetCommandRedo(ICommand command) {
            this.command = command;
        }

        public void Execute() {
            command.Redo();
        }

        public void Redo() {
            command.Redo();
        }

        public void Undo() {
            command.Undo();
        }
    }
}
