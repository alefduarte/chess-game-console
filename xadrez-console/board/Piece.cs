﻿namespace board
{
    class Pieces
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public int QtyMoviments { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Position position, Board board, Color color)
        {
            Position = position;
            Board = board;
            Color = Color;
            QtyMoviments = 0;
        }
    }
}