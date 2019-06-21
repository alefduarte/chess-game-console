using System;
using board;

namespace chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color) { }
        public override string ToString() => "Ki";
    }
}
