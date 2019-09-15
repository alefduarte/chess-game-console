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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.Write("Source: ");
                        Position source = Screen.ReadChessPosition().ToPosition();

                        match.ValidateSourcePosition(source);

                        bool[,] possiblePositions = match.Board.Piece(source).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, possiblePositions);

                        Console.Write("Target: ");
                        Position target = Screen.ReadChessPosition().ToPosition();

                        match.ValidateTargetPosition(source, target);

                        match.Play(source, target);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }
                Console.Clear();
                Screen.PrintMatch(match);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
