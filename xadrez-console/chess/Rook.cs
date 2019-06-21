using System;
using board;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color) { }
        public override string ToString() => "Ro";
    }
}
