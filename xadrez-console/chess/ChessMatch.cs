using System;
using board;

namespace chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool GameOver { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            GameOver = false;
            PlacePieces();
        }

        private void PlacePieces()
        {
            Board.PlacePiece(new King(Board, Color.White), new ChessPosition('C', 1).ToPosition());
            Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('D', 1).ToPosition());
        }

        public void Move(Position source, Position target)
        {
            Piece p = Board.RemovePiece(source);
            p.IncreaseMove();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
        }

        public void Play(Position source, Position target)
        {
            Move(source, target);
            Turn++;
            ChangePlayer();
        }

        public void ValidateSourcePosition(Position pos)
        {
            if(Board.Piece(pos) == null)
            {
                throw new BoardException("No available pieces at chosen position!");
            }

            if(CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException("Chosen Piece not yours!");
            }

            if(!Board.Piece(pos).AnyPossibleMove())
            {
                throw new BoardException("No available moves for given piece!");
            }
        }

        public void ValidateTargetPosition(Position source, Position target)
        {
            if(!Board.Piece(source).CanMoveTo(target))
            {
                throw new BoardException("Invalid target position!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
                CurrentPlayer = Color.Black;
            else
                CurrentPlayer = Color.White;
        }
    }
}
