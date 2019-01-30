using System;
namespace TicTacToe
{
    public interface IConsole
    {
        String ReadLine();

        void WriteLine(String line);
    }
}
