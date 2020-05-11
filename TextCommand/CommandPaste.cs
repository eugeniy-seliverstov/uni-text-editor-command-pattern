namespace TextCommand {
    class CommandPaste : ICommand {
        private Receiver receiver;
        private int startIndex;
        private int endIndex;

        public CommandPaste(Receiver receiver, int startIndex) {
            this.receiver = receiver;
            this.startIndex = startIndex;
        }

        public void Execute() {
            receiver.Paste(startIndex);
            endIndex = startIndex + receiver.Buffer.Length - 1;
        }

        public void Redo() {
            receiver.Paste(startIndex);
            endIndex = startIndex + receiver.Buffer.Length - 1;
        }

        public void Undo() {
            receiver.Delete(startIndex, endIndex);
        }
    }
}
