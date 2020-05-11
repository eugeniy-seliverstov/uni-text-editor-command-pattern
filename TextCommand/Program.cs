using System;
using System.IO;

interface ICommand
{
    void Execute();
    void Undo();
    void Redo();
}

namespace TextCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("string.txt");
            string str = reader.ReadLine();

            Client exc = new Client(str, "comand.txt");
            exc.ExecuteAllCommand();

            Console.ReadKey();
        }
    }
}
