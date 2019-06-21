using System;
using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color) { }
        public override string ToString() => "Pa";
    }
}
