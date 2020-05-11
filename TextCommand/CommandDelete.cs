namespace TextCommand {
    class CommandDelete : ICommand {
        private Receiver receiver;
        private int startIndex;
        private int endIndex;

        protected string oldStr;

        public CommandDelete(Receiver receiver, int startIndex, int endIndex) {
            this.receiver = receiver;
            this.startIndex = startIndex;
            this.endIndex = endIndex;
        }

        public void Execute() {
            oldStr = receiver.Delete(startIndex, endIndex);
        }

        public void Redo() {
            oldStr = receiver.Delete(startIndex, endIndex);
        }

        public void Undo() {
            receiver.Insert(oldStr, startIndex);
        }
    }
}
