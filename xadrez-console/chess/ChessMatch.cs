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
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            GameOver = false;
            Check = false;
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
            foreach (Piece p in Pieces)
            {
                if (p.Color == color)
                    aux.Add(p);
            }
            aux.ExceptWith(GetCapturedPieces(color));
            return aux;
        }

        private Color Opponent(Color color) => (color == Color.White) ? Color.Black : Color.White;

        private Piece King(Color color)
        {
            foreach (Piece p in PiecesInGame(color))
            {
                if (p is King)
                {
                    return p;
                }
            }
            return null;
        }

        public bool IsCheck(Color color)
        {
            Piece K = King(color);
            if (K == null)
                throw new BoardException(color + " King is not on the board");

            foreach (Piece p in PiecesInGame(Opponent(color)))
            {
                bool[,] mat = p.PossibleMoves();
                if (mat[K.Position.Row, K.Position.Column])
                    return true;
            }
            return false;
        }

        public bool IsCheckmate(Color color)
        {
            if (!IsCheck(color)) return false;

            foreach (Piece p in PiecesInGame(color))
            {
                bool[,] mat = p.PossibleMoves();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position source = p.Position;
                            Position target = new Position(i, j);
                            Piece capturedPiece = Move(source, target);
                            bool testCheck = IsCheck(color);
                            UndoMove(source, target, capturedPiece);
                            if (!testCheck) return false;
                        }
                    }
                }
            }
            return true;
        }
        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }

        private void PlacePieces()
        {
            PlaceNewPiece('D', 1, new King(Board, Color.White));
            PlaceNewPiece('C', 1, new Rook(Board, Color.White));
            PlaceNewPiece('H', 7, new Rook(Board, Color.White));
            PlaceNewPiece('A', 8, new King(Board, Color.Black));
            PlaceNewPiece('B', 8, new Rook(Board, Color.Black));
        }

        public Piece Move(Position source, Position target)
        {
            Piece p = Board.RemovePiece(source);
            p.IncreaseMove();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
            if (capturedPiece != null)
                CapturedPieces.Add(capturedPiece);
            return capturedPiece;
        }

        public void UndoMove(Position source, Position target, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(target);
            p.DecreaseMove();
            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, target);
                CapturedPieces.Remove(capturedPiece);
            }
            Board.PlacePiece(p, source);

        }

        public void Play(Position source, Position target)
        {
            Piece capturedPiece = Move(source, target);

            if (IsCheck(CurrentPlayer))
            {
                UndoMove(source, target, capturedPiece);
                throw new BoardException("You cannot move yourself into check");
            }

            if (IsCheck(Opponent(CurrentPlayer))) { Check = true; } else { Check = false; };

            if (IsCheckmate(Opponent(CurrentPlayer))) { GameOver = true; }
            else
            {
                Turn++;
                ChangePlayer();
            };

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
