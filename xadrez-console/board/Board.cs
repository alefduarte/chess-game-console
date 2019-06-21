namespace board
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[rows, columns];
        }

        public Piece Piece(int row, int column) => Pieces[row, column];

        public Piece Piece(Position position) => Pieces[position.Row, position.Column];

        public void AddPiece(Piece piece, Position position)
        {
            if (PieceExists(position))
            {
                throw new BoardException("Piece already exists at given position!");
            }
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public bool PieceExists(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public bool ValidPosition(Position position) => (position.Row < 0 || position.Row > Rows
            || position.Column < 0 || position.Column > Columns) ? false : true;

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid Position");
            }
        }
    }
}
