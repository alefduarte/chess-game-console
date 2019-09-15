using board;
using chess;
using System;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while(!match.GameOver)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.Write("Source: ");
                    Position source = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    match.Move(source, destination);
                }
                Screen.PrintBoard(match.Board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
