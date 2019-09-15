using System;
using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color) { }

        public override bool[,] PossibleMoves()
        {
            throw new NotImplementedException();
        }

        public override string ToString() => "Pa";
    }
}
