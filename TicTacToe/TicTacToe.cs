using System;
using System.Linq;

namespace TicTacToe
{
    internal class TicTacToe : IGame
    {
        public static readonly String[] players = new String[] { "X", "O" };
        String currentPlayer;
        String[] slots;
        IGame iGame;

        public TicTacToe()
        {
            iGame = (IGame)this;
        }

        String IGame.this[Int32 position]
        {
            get 
            {
                return slots[position - 1];
            }
        }

        String IGame.Winner 
        {
            get
            {
                return players.ToList().Find((player) => IsGameWinFor(player));
            }
        }

        Boolean IGame.Play(Int32 position)
        {
            if (iGame[position] == null)
            {
                slots[position - 1] = currentPlayer;
                SwitchPlayer();
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void ResetGame()
        {
            currentPlayer = players[0];
            slots = new String[9];
        }

        internal String CurrentPlayer()
        {
            return currentPlayer;
        }

        internal void SwitchPlayer()
        {
            this.currentPlayer = players.ToList().Find((player) => player != currentPlayer);
        }

        internal bool IsGameOver()
        {
            return IsGameWin() || IsGameDraw();
        }

        internal bool IsGameDraw()
        {
            return IsBoardFull() && !IsGameWin();
        }

        internal bool IsBoardFull()
        {
            return slots.Aggregate(true, (result, slot) => result && players.Contains(slot));
        }

        internal bool IsGameWin()
        {
            return iGame.Winner != null;
        }

        internal bool IsGameWinFor(String player)
        {
            return IsHorizontalWin(player) || IsVerticalWin(player) || IsDiagonalWin(player);
        }

        internal bool IsHorizontalWin(String player)
        {
            return (iGame[7] == player && iGame[8] == player && iGame[9] == player) ||
             (iGame[4] == player && iGame[5] == player && iGame[6] == player) ||
             (iGame[1] == player && iGame[2] == player && iGame[3] == player);
        }

        internal bool IsVerticalWin(String player)
        {
            return (iGame[7] == player && iGame[4] == player && iGame[1] == player) ||
             (iGame[8] == player && iGame[5] == player && iGame[2] == player) ||
             (iGame[9] == player && iGame[6] == player && iGame[3] == player);
        }

        internal bool IsDiagonalWin(String player)
        {
            return (iGame[7] == player && iGame[5] == player && iGame[3] == player) ||
             (iGame[9] == player && iGame[5] == player && iGame[1] == player);
        }
    }
}