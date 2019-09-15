using System.Collections.Generic;
using board;

namespace chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool GameOver { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            GameOver = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PlacePieces();
        }

        public HashSet<Piece> GetCapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in CapturedPieces)
            {
                if (p.Color == color)
                    aux.Add(p);
            }

            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in CapturedPieces)
            {
                if (p.Color == color)
                    aux.Add(p);
            }
            aux.ExceptWith(GetCapturedPieces(color));
            return aux;
        }

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece('C', 1, new King(Board, Color.White));
            PlaceNewPiece('D', 1, new Rook(Board, Color.White));
            PlaceNewPiece('C', 8, new King(Board, Color.Black));
            PlaceNewPiece('D', 8, new Rook(Board, Color.Black));
        }

        public void Move(Position source, Position target)
        {
            Piece p = Board.RemovePiece(source);
            p.IncreaseMove();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
            if (capturedPiece != null)
                CapturedPieces.Add(capturedPiece);
        }

        public void Play(Position source, Position target)
        {
            Move(source, target);
            Turn++;
            ChangePlayer();
        }

        public void ValidateSourcePosition(Position pos)
        {
            if (Board.Piece(pos) == null)
            {
                throw new BoardException("No available pieces at chosen position!");
            }

            if (CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException("Chosen Piece not yours!");
            }

            if (!Board.Piece(pos).AnyPossibleMove())
            {
                throw new BoardException("No available moves for given piece!");
            }
        }

        public void ValidateTargetPosition(Position source, Position target)
        {
            if (!Board.Piece(source).CanMoveTo(target))
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
