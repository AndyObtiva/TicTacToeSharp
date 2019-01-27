using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeBoard board = new TicTacToeBoard();
            Boolean playAgain = false;
            do
            {
                board.play();
                Console.WriteLine("Play Again? (Y/N): ");
                Char playAgainInput = Console.ReadLine()[0];
                playAgain = playAgainInput.ToString().ToUpper() == "Y";
            } while (playAgain);
        }
    }
}
