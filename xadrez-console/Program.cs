using board;
using System;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            Screen.PrintBoard(board);
        }
    }
}
