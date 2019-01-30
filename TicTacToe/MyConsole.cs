using System;

namespace TicTacToe
{
    public class MyConsole : IConsole
    {
        public String ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(String line)
        {
            Console.WriteLine(line);
        }
    }
}
