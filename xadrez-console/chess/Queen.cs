﻿using System;
using board;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color) { }

        public override bool[,] PossibleMoves()
        {
            throw new NotImplementedException();
        }

        public override string ToString() => "Qu";
    }
}
