using System;

namespace TextCommand {
    class Receiver {
        private string str;

        public string Buffer { get; set; }

        public Receiver(string str) {
            this.str = str;
            Buffer = "";
        }

        public void Insert(string str, int start) {
            Console.WriteLine($"Вставка строки {str} в строку {this.str} с {start} индекса");
            this.str = this.str.Insert(start, str);
        }

        public void Copy(int start, int end) {
            Console.WriteLine($"Копирование в буфер строки {str.Substring(start, end - start + 1)} с {start} до {end} индекса");
            Buffer = str.Substring(start, end - start + 1);
        }

        public void Paste(int start) {
            Console.WriteLine($"Вставка строки {Buffer} из буфера в строку {str} с {start} индекса");
            str = str.Insert(start, Buffer);
        }

        public string Delete(int start, int end) {
            Console.WriteLine($"Удаление в строке {str} с {start} до {end} индекса");
            string oldStr = str.Substring(start, end - start + 1);
            str = str.Remove(start, end - start + 1);
            return oldStr;
        }

        public void ClearBuffer() {
            Buffer = "";
        }

        public void ShowStr() {
            Console.WriteLine($"\nРезультат: {str}");
        }
    }
}
