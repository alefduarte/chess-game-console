using System;
using board;

namespace chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool GameOver { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            GameOver = false;
            AddPieces();
        }

        private void AddPieces()
        {
            Board.PlacePiece(new King(Board, Color.White), new ChessPosition('C', 1).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('D', 1).ToPosition());
        }

        public void Move(Position source, Position dest)
        {
            Piece p = Board.RemovePiece(source);
            p.IncreaseMovement();
            Piece capturedPiece = Board.RemovePiece(dest);
            Board.PlacePiece(p, dest);
        }

    }
}
