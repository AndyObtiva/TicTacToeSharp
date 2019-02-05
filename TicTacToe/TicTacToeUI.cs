using System;

namespace TicTacToe
{
    public class TicTacToeUI
    {
        IConsole console;
        TicTacToe game;
        IGame iGame;

        public TicTacToeUI(IConsole specifiedConsole)
        {
            this.console = specifiedConsole;
            game = new TicTacToe();
            iGame = (IGame)game;
        }

        public void Play()
        {
            game.ResetGame();
            do
            {
                DisplayBoard();
                Int32 position = InputMove();
                PlayMove(position);
            } while (!game.IsGameOver());
            DisplayBoard();
            String endOfGameMessage = game.IsGameDraw() ? "Cat's Game!" : $"Player {iGame.Winner} Won!";
            console.WriteLine(endOfGameMessage);
        }

        void DisplayBoard()
        {
            console.WriteLine($"{DisplaySlot(7)} | {DisplaySlot(8)} | {DisplaySlot(9)}");
            console.WriteLine($"{DisplaySlot(4)} | {DisplaySlot(5)} | {DisplaySlot(6)}");
            console.WriteLine($"{DisplaySlot(1)} | {DisplaySlot(2)} | {DisplaySlot(3)}");
        }

        String DisplaySlot(Int32 slotNumber)
        {
            return iGame[slotNumber] != null ? iGame[slotNumber] : slotNumber.ToString();
        }

        Int32 InputMove()
        {
            console.WriteLine($"Please enter a number not filled in yet (Player {game.CurrentPlayer()}): ");
            String move = console.ReadLine()[0].ToString();
            return Int32.Parse(move);
        }

        void PlayMove(Int32 position)
        {
            Boolean isMoveValid = iGame.Play(position);
            if (!isMoveValid)
            {
                console.WriteLine("Number filled in already; pick a different number!");
            }
        }
    }
}