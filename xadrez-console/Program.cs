using board;
using chess;
using System;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            ChessPosition position = new ChessPosition('A', 1);

            Console.WriteLine(position);

            Console.WriteLine(position.ToPosition());
        }
    }
}
