namespace TextCommand {
    class CommandInsert : ICommand {
        private Receiver receiver;
        private int index;
        private string str;

        public CommandInsert(Receiver receiver, string str, int index) {
            this.receiver = receiver;
            this.str = str;
            this.index = index;
        }

        public void Execute() {
            receiver.Insert(str, index);
        }

        public void Redo() {
            receiver.Insert(str, index);
        }

        public void Undo() {
            receiver.Delete(index, index + str.Length - 1);
        }
    }
}
