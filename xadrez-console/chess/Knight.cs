using System;
using board;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color) { }
        public override string ToString() => "Kn";
    }
}
