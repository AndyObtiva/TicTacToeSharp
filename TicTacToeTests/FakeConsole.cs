using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe;

namespace TicTacToeTests
{
    public class FakeConsole : IConsole
    {
        private Queue<string> readLineQueue;
        StringBuilder writeBufferBuilder = new StringBuilder();


        public FakeConsole(Queue<string> readLineQueue)
        {
            this.readLineQueue = readLineQueue;
        }

        public string ReadLine()
        {
            return readLineQueue.Dequeue();
        }

        public string GetWriteBuffer()
        {
            return writeBufferBuilder.ToString();
        }

        public void WriteLine(string line)
        {
            this.writeBufferBuilder.AppendLine(line);
        }
    }
}
