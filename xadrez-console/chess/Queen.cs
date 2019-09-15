using System;
using board;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color) { }

        private bool CanMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;

        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            // up
            pos.setValues(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row -= 1;
            }

            // down
            pos.setValues(Position.Row + 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Row += 1;
            }

            // right
            pos.setValues(Position.Row, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column += 1;
            }

            // left
            pos.setValues(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column -= 1;
            }

            // upleft
            pos.setValues(Position.Row - 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Row - 1, pos.Column - 1);
            }

            // upright
            pos.setValues(Position.Row - 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Row - 1, pos.Column + 1);
            }

            // downright
            pos.setValues(Position.Row + 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Row + 1, pos.Column + 1);
            }

            // downleft
            pos.setValues(Position.Row + 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Row + 1, pos.Column - 1);
            }

            return mat;
        }

        public override string ToString() => "Qu";
    }
}
