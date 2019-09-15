using System;
using board;

namespace chess
{
    class King : Piece
    {
        private ChessMatch Match;

        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;

        }

        private bool TestRookCastling(Position position)
        {
            Piece p = Board.Piece(position);
            return p != null && p is Rook && p.Color == Color && p.MoveCount == 0;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            // up
            pos.setValues(Position.Row - 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // upright
            pos.setValues(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // right
            pos.setValues(Position.Row, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // downright
            pos.setValues(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // down
            pos.setValues(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // downleft
            pos.setValues(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // left
            pos.setValues(Position.Row, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // upleft
            pos.setValues(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // #specialMove Castling
            if (MoveCount == 0 && !Match.Check)
            {
                // #specialMove kingside rook
                Position posR1 = new Position(Position.Row, Position.Column + 3);
                if (TestRookCastling(posR1))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                        mat[Position.Row, Position.Column + 2] = true;
                }
                // #specialMove queenside rook
                Position posR2 = new Position(Position.Row, Position.Column - 4);
                if (TestRookCastling(posR2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                        mat[Position.Row, Position.Column - 2] = true;
                }
            }

            return mat;
        }

        public override string ToString() => "Ki";
    }
}
