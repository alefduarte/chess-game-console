using System;
using board;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color) { }

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
            pos.setValues(Position.Row - 1, Position.Column - 2);

            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // upright
            pos.setValues(Position.Row - 2, Position.Column - 1);

            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // right
            pos.setValues(Position.Row - 2, Position.Column + 1);

            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // downright
            pos.setValues(Position.Row - 1, Position.Column + 2);

            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // down
            pos.setValues(Position.Row + 1, Position.Column + 2);

            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // downleft
            pos.setValues(Position.Row + 2, Position.Column + 1);

            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // left
            pos.setValues(Position.Row + 2, Position.Column - 1);

            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;

            // upleft
            pos.setValues(Position.Row + 1, Position.Column - 2);

            if (Board.ValidPosition(pos) && CanMove(pos)) mat[pos.Row, pos.Column] = true;
            return mat;
        }

        public override string ToString() => "Kn";
    }
}
