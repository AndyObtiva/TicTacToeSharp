using System;

namespace TicTacToe
{
    class GameLauncher
    {
        static void Main(string[] args)
        {
            TicTacToeUI gameUI = new TicTacToeUI(new MyConsole());
            Boolean playAgain = false;
            do
            {
                gameUI.Play();
                Console.WriteLine("Play Again? (Y/N): ");
                Char playAgainInput = Console.ReadLine()[0];
                playAgain = playAgainInput.ToString().ToUpper() == "Y";
            } while (playAgain);
        }
    }
}
