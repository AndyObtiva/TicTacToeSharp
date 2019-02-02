using System;
using System.Linq;

namespace TicTacToe
{
    internal class TicTacToe : IGame
    {
        public static readonly String[] players = new String[] { "X", "O" };
        String currentPlayer = players[0];

        String IGame.this[Int32 position] => throw new NotImplementedException();

        String IGame.Winner => throw new NotImplementedException();

        Boolean IGame.Play(Int32 position)
        {
            throw new NotImplementedException();
        }
    }
}