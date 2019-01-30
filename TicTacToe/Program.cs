using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeBoard board = new TicTacToeBoard(new MyConsole());
            Boolean playAgain = false;
            do
            {
                board.Play();
                Console.WriteLine("Play Again? (Y/N): ");
                Char playAgainInput = Console.ReadLine()[0];
                playAgain = playAgainInput.ToString().ToUpper() == "Y";
            } while (playAgain);
        }
    }
}
