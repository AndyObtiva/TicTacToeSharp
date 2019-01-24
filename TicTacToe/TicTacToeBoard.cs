using System;

namespace TicTacToe
{
    internal class TicTacToeBoard
    {
        public TicTacToeBoard()
        {
        }

        internal void Display()
        {
            Console.WriteLine("7 | 8 | 9");
            Console.WriteLine("4 | 5 | 6");
            Console.WriteLine("1 | 2 | 3");
        }

        internal void play()
        {
            do
            {
                AcceptMove();
                Display();
            } while (!IsGameOver());
        }

        internal void AcceptMove()
        {
            //TODO implement
        }

        internal bool IsGameOver()
        {
            return true;
        }
    }
}