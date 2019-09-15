using System;
using board;

namespace chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int round;
        private Color currentPlayer;
        public bool GameOver { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            round = 1;
            currentPlayer = Color.White;
            GameOver = false;
            AddPieces();
        }

        private void AddPieces()
        {
            Board.AddPiece(new King(Board, Color.White), new ChessPosition('C', 1).ToPosition());
        }

        public void Move(Position source, Position dest)
        {
            Piece p = Board.RemovePiece(source);
            p.IncreaseMovement();
            Piece capturedPiece = Board.RemovePiece(dest);
            Board.AddPiece(p, dest);
        }

    }
}
