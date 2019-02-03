using System;
using System.Linq;

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
                InputMove();
                SwitchPlayer();
            } while (!game.IsGameOver());
            DisplayBoard();
            if (game.IsGameDraw())
            {
                console.WriteLine("Cat's Game!");
            }
            else
            {
                console.WriteLine($"Player {iGame.Winner} Won!");
            }
        }

        internal void DisplayBoard()
        {
            console.WriteLine($"{DisplaySlot(7)} | {DisplaySlot(8)} | {DisplaySlot(9)}");
            console.WriteLine($"{DisplaySlot(4)} | {DisplaySlot(5)} | {DisplaySlot(6)}");
            console.WriteLine($"{DisplaySlot(1)} | {DisplaySlot(2)} | {DisplaySlot(3)}");
        }

        internal String DisplaySlot(Int32 slotNumber)
        {
            return iGame[slotNumber] != null ? iGame[slotNumber] : slotNumber.ToString();
        }

        internal void InputMove()
        {
            console.WriteLine($"Please enter a number not filled in yet (Player {game.CurrentPlayer()}): ");
            String move = console.ReadLine()[0].ToString();
            Int32 moveNumber = Int32.Parse(move);
            if (!IsMoveValid(moveNumber))
            {
                console.WriteLine("Number filled in already; pick a different number!");
            }
            else
            {
                AcceptMove(moveNumber);
            }
        }

        internal void SwitchPlayer()
        {
            game.SwitchPlayer();
        }

        private bool IsMoveValid(Int32 moveNumber)
        {
            return game.IsMoveValid(moveNumber);
        }

        internal void AcceptMove(Int32 moveNumber)
        {
            iGame.Play(moveNumber);
        }

    }
}