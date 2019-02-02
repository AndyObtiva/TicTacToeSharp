using System;
using Xunit;
using System.Collections.Generic;
using TicTacToe;

namespace TicTacToeTests
{
    public class UnitTest1
    {
        [Fact]
        public void PlayerXWins()
        {
            Queue<string> readLineQueue = new Queue<string>();
            readLineQueue.Enqueue("1");
            readLineQueue.Enqueue("2");
            readLineQueue.Enqueue("3");
            readLineQueue.Enqueue("4");
            readLineQueue.Enqueue("5");
            readLineQueue.Enqueue("6");
            readLineQueue.Enqueue("7");
            FakeConsole fakeConsole = new FakeConsole(readLineQueue);
            TicTacToeUI board = new TicTacToeUI(fakeConsole);
            Assert.Equal("", fakeConsole.GetWriteBuffer());
            board.Play();
            Assert.Equal("7 | 8 | 9\n4 | 5 | 6\n1 | 2 | 3\nPlease enter a number not filled in yet (Player X): \n7 | 8 | 9\n4 | 5 | 6\nX | 2 | 3\nPlease enter a number not filled in yet (Player O): \n7 | 8 | 9\n4 | 5 | 6\nX | O | 3\nPlease enter a number not filled in yet (Player X): \n7 | 8 | 9\n4 | 5 | 6\nX | O | X\nPlease enter a number not filled in yet (Player O): \n7 | 8 | 9\nO | 5 | 6\nX | O | X\nPlease enter a number not filled in yet (Player X): \n7 | 8 | 9\nO | X | 6\nX | O | X\nPlease enter a number not filled in yet (Player O): \n7 | 8 | 9\nO | X | O\nX | O | X\nPlease enter a number not filled in yet (Player X): \nX | 8 | 9\nO | X | O\nX | O | X\nPlayer X Wins!\n", fakeConsole.GetWriteBuffer());
        }
        [Fact]
        public void PlayerOWins()
        {
            Queue<string> readLineQueue = new Queue<string>();
            readLineQueue.Enqueue("1");
            readLineQueue.Enqueue("2");
            readLineQueue.Enqueue("4");
            readLineQueue.Enqueue("5");
            readLineQueue.Enqueue("3");
            readLineQueue.Enqueue("8");
            FakeConsole fakeConsole = new FakeConsole(readLineQueue);
            TicTacToeUI board = new TicTacToeUI(fakeConsole);
            Assert.Equal("", fakeConsole.GetWriteBuffer());
            board.Play();
            Assert.Equal("7 | 8 | 9\n4 | 5 | 6\n1 | 2 | 3\nPlease enter a number not filled in yet (Player X): \n7 | 8 | 9\n4 | 5 | 6\nX | 2 | 3\nPlease enter a number not filled in yet (Player O): \n7 | 8 | 9\n4 | 5 | 6\nX | O | 3\nPlease enter a number not filled in yet (Player X): \n7 | 8 | 9\nX | 5 | 6\nX | O | 3\nPlease enter a number not filled in yet (Player O): \n7 | 8 | 9\nX | O | 6\nX | O | 3\nPlease enter a number not filled in yet (Player X): \n7 | 8 | 9\nX | O | 6\nX | O | X\nPlease enter a number not filled in yet (Player O): \n7 | O | 9\nX | O | 6\nX | O | X\nPlayer O Wins!\n", fakeConsole.GetWriteBuffer());
        }
        [Fact]
        public void PlayerDraw()
        {
            Queue<string> readLineQueue = new Queue<string>();
            readLineQueue.Enqueue("1");
            readLineQueue.Enqueue("2");
            readLineQueue.Enqueue("4");
            readLineQueue.Enqueue("5");
            readLineQueue.Enqueue("8");
            readLineQueue.Enqueue("7");
            readLineQueue.Enqueue("3");
            readLineQueue.Enqueue("6");
            readLineQueue.Enqueue("9");
            FakeConsole fakeConsole = new FakeConsole(readLineQueue);
            TicTacToeUI board = new TicTacToeUI(fakeConsole);
            Assert.Equal("", fakeConsole.GetWriteBuffer());
            board.Play();
            Assert.Equal("7 | 8 | 9\n4 | 5 | 6\n1 | 2 | 3\nPlease enter a number not filled in yet (Player X): \n7 | 8 | 9\n4 | 5 | 6\nX | 2 | 3\nPlease enter a number not filled in yet (Player O): \n7 | 8 | 9\n4 | 5 | 6\nX | O | 3\nPlease enter a number not filled in yet (Player X): \n7 | 8 | 9\nX | 5 | 6\nX | O | 3\nPlease enter a number not filled in yet (Player O): \n7 | 8 | 9\nX | O | 6\nX | O | 3\nPlease enter a number not filled in yet (Player X): \n7 | X | 9\nX | O | 6\nX | O | 3\nPlease enter a number not filled in yet (Player O): \nO | X | 9\nX | O | 6\nX | O | 3\nPlease enter a number not filled in yet (Player X): \nO | X | 9\nX | O | 6\nX | O | X\nPlease enter a number not filled in yet (Player O): \nO | X | 9\nX | O | O\nX | O | X\nPlease enter a number not filled in yet (Player X): \nO | X | X\nX | O | O\nX | O | X\nIt's a draw!\n", fakeConsole.GetWriteBuffer());
        }
    }
}
