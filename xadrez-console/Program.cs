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
                Board board = new Board(8, 8);

                board.AddPiece(new King(board, Color.Black), new Position(0, 0));
                board.AddPiece(new Knight(board, Color.Black), new Position(1, 3));
                board.AddPiece(new Rook(board, Color.Black), new Position(2, 4));
                board.AddPiece(new Pawn(board, Color.Black), new Position(4, 4));
                board.AddPiece(new Queen(board, Color.Black), new Position(2, 2));
                board.AddPiece(new Bishop(board, Color.White), new Position(3, 4));
                Screen.PrintBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
