namespace TextCommand {
    class CommandCopy : ICommand {
        private Receiver receiver;
        private int startIndex;
        private int endIndex;
        private string oldBuffer;

        public CommandCopy(Receiver receiver, int startIndex, int endIndex) {
            this.receiver = receiver;
            this.startIndex = startIndex;
            this.endIndex = endIndex;
        }

        public void Execute() {
            oldBuffer = receiver.Buffer;
            receiver.Copy(startIndex, endIndex);
        }

        public void Redo() {
            oldBuffer = receiver.Buffer;
            receiver.Copy(startIndex, endIndex);
        }

        public void Undo() {
            receiver.Buffer = oldBuffer;
        }
    }
}
