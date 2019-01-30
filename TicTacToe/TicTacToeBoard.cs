using System;
using System.Linq;

namespace TicTacToe
{
    public class TicTacToeBoard
    {
        static Char[] players = new Char[] { 'X', 'O' };
        Char currentPlayer = players[0];
        Char[] slots = null;
        IConsole console = null;

        public TicTacToeBoard(IConsole specifiedConsole)
        {
            this.console = specifiedConsole;
        }

        public void Play()
        {
            ResetGame();
            do
            {
                DisplayBoard();
                InputMove();
                SwitchPlayer();
            } while (!IsGameOver());
            DisplayBoard();
            if (IsGameDraw())
            {
                console.WriteLine("It's a draw!");
            }
            else
            {
                console.WriteLine($"Player {GetWinner()} Wins!");
            }
        }

        internal void ResetGame()
        {
            currentPlayer = players[0];
            slots = Enumerable.Range(1, 9).ToList().ConvertAll((input) => input.ToString()[0]).ToArray();
        }

        internal void DisplayBoard()
        {
            console.WriteLine($"{GetSlot(7)} | {GetSlot(8)} | {GetSlot(9)}");
            console.WriteLine($"{GetSlot(4)} | {GetSlot(5)} | {GetSlot(6)}");
            console.WriteLine($"{GetSlot(1)} | {GetSlot(2)} | {GetSlot(3)}");
        }

        internal Char GetSlot(Int32 slotNumber)
        {
            return slots[slotNumber - 1];
        }

        internal void InputMove()
        {
            console.WriteLine($"Please enter a number not filled in yet (Player {currentPlayer}): ");
            Char moveCharacter = console.ReadLine()[0];
            Int32 moveNumber = Int32.Parse(moveCharacter.ToString());
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
            currentPlayer = players.ToList().Find((player) => player != currentPlayer);
        }

        private bool IsMoveValid(Int32 moveNumber)
        {
            return !players.Contains(slots[moveNumber - 1]);
        }

        internal void AcceptMove(Int32 moveNumber)
        {
            slots[moveNumber - 1] = currentPlayer;
        }

        internal bool IsGameOver()
        {
            return IsGameWin() || IsGameDraw();
        }

        internal bool IsGameWin()
        {
            return IsGameWinFor(players[0]) || IsGameWinFor(players[1]);
        }

        internal bool IsGameWinFor(Char player)
        {
            return IsHorizontalWin(player) || IsVerticalWin(player) || IsDiagonalWin(player);
        }

        internal Char GetWinner()
        {
            return players.ToList().Find((player) => IsGameWinFor(player));
        }

        internal bool IsGameFull()
        {
            return slots.Aggregate(true, (result, slot) => result && players.Contains(slot));
        }

        internal bool IsGameDraw()
        {
            return !IsGameWin() && IsGameFull();
        }

        internal bool IsHorizontalWin(Char player)
        {
            return (GetSlot(7) == player && GetSlot(8) == player && GetSlot(9) == player) ||
             (GetSlot(4) == player && GetSlot(5) == player && GetSlot(6) == player) ||
             (GetSlot(1) == player && GetSlot(2) == player && GetSlot(3) == player);
        }

        internal bool IsVerticalWin(Char player)
        {
            return (GetSlot(7) == player && GetSlot(4) == player && GetSlot(1) == player) ||
             (GetSlot(8) == player && GetSlot(5) == player && GetSlot(2) == player) ||
             (GetSlot(9) == player && GetSlot(6) == player && GetSlot(3) == player);
        }

        internal bool IsDiagonalWin(Char player)
        {
            return (GetSlot(7) == player && GetSlot(5) == player && GetSlot(3) == player) ||
             (GetSlot(9) == player && GetSlot(5) == player && GetSlot(1) == player);
        }
    }
}