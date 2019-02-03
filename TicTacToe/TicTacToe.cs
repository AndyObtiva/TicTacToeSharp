using System;
using System.Linq;

namespace TicTacToe
{
    internal class TicTacToe : IGame
    {
        public static readonly String[] players = new String[] { "X", "O" };
        String currentPlayer = null;
        String[] slots = null;

        internal void ResetGame()
        {
            currentPlayer = players[0];
            slots = new String[9];
        }

        String IGame.this[Int32 position]
        {
            get 
            {
                return Move(position);
            }
        }

        internal String CurrentPlayer()
        {
            return currentPlayer;
        }

        internal String Move(Int32 position)
        {
            return slots[position - 1];
        }

        String IGame.Winner 
        {
            get
            {
                return GetWinner();
            }
        }

        internal Boolean IsMoveValid(Int32 position)
        {
            return Move(position) == null;
        }

        Boolean IGame.Play(Int32 position)
        {
            if (IsMoveValid(position))
            {
                slots[position - 1] = currentPlayer;
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void SwitchPlayer()
        {
            this.currentPlayer = players.ToList().Find((player) => player != currentPlayer);
        }


        internal bool IsGameOver()
        {
            return IsGameWin() || IsGameDraw();
        }

        internal bool IsGameWin()
        {
            return IsGameWinFor(players[0]) || IsGameWinFor(players[1]);
        }

        internal bool IsGameWinFor(String player)
        {
            return IsHorizontalWin(player) || IsVerticalWin(player) || IsDiagonalWin(player);
        }

        internal String GetWinner()
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

        internal bool IsHorizontalWin(String player)
        {
            return (Move(7) == player && Move(8) == player && Move(9) == player) ||
             (Move(4) == player && Move(5) == player && Move(6) == player) ||
             (Move(1) == player && Move(2) == player && Move(3) == player);
        }

        internal bool IsVerticalWin(String player)
        {
            return (Move(7) == player && Move(4) == player && Move(1) == player) ||
             (Move(8) == player && Move(5) == player && Move(2) == player) ||
             (Move(9) == player && Move(6) == player && Move(3) == player);
        }

        internal bool IsDiagonalWin(String player)
        {
            return (Move(7) == player && Move(5) == player && Move(3) == player) ||
             (Move(9) == player && Move(5) == player && Move(1) == player);
        }
    }
}