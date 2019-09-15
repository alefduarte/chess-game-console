using System;
using board;

namespace chess
{
    class Pawn : Piece
    {
        private ChessMatch Match;

        public Pawn(Board board, Color color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }

        private bool AnyEnemy(Position pos)
        {
            Piece piece = Board.Piece(pos);
            return piece != null && piece.Color != Color;
        }

        private bool IsAvailable(Position pos)
        {
            return Board.Piece(pos) == null;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                // up
                pos.setValues(Position.Row - 1, Position.Column);
                if (Board.ValidPosition(pos) && IsAvailable(pos)) mat[pos.Row, pos.Column] = true;

                // first up
                pos.setValues(Position.Row - 2, Position.Column);
                if (Board.ValidPosition(pos) && IsAvailable(pos) && MoveCount == 0)
                    mat[pos.Row, pos.Column] = true;

                // eat upright
                pos.setValues(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && AnyEnemy(pos)) mat[pos.Row, pos.Column] = true;

                // eat upleft
                pos.setValues(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && AnyEnemy(pos)) mat[pos.Row, pos.Column] = true;

                // #specialMove EnPassant
                if(Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if(Board.ValidPosition(left) && AnyEnemy(left) && Board.Piece(left) == Match.EnPassantVulnerable)
                    {
                        mat[left.Row - 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(right) && AnyEnemy(right) && Board.Piece(right) == Match.EnPassantVulnerable)
                    {
                        mat[right.Row -1 , right.Column] = true;
                    }
                }
            }
            else
            {
                // down
                pos.setValues(Position.Row + 1, Position.Column);
                if (Board.ValidPosition(pos) && IsAvailable(pos)) mat[pos.Row, pos.Column] = true;

                // first down
                pos.setValues(Position.Row + 2, Position.Column);
                if (Board.ValidPosition(pos) && IsAvailable(pos) && MoveCount == 0)
                    mat[pos.Row, pos.Column] = true;

                // eat downright
                pos.setValues(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && AnyEnemy(pos)) mat[pos.Row, pos.Column] = true;

                // eat downleft
                pos.setValues(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && AnyEnemy(pos)) mat[pos.Row, pos.Column] = true;

                // #specialMove EnPassant
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.ValidPosition(left) && AnyEnemy(left) && Board.Piece(left) == Match.EnPassantVulnerable)
                    {
                        mat[left.Row + 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.ValidPosition(right) && AnyEnemy(right) && Board.Piece(right) == Match.EnPassantVulnerable)
                    {
                        mat[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }

        public override string ToString() => "Pa";
    }
}
