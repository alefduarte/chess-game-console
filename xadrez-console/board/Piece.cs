namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public int MoveCount { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            MoveCount = 0;
        }

        public void IncreaseMove() => MoveCount++;


        public void DecreaseMove() => MoveCount--;

        public bool AnyPossibleMove()
        {
            bool[,] mat = PossibleMoves();
            for (int i=0; i<Board.Rows; i++)
            {
                for (int j=0; j<Board.Columns; j++)
                {
                    if(mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PossibleMove(Position pos)
        {
            return PossibleMoves()[pos.Row, pos.Column];
        }

        public abstract bool[,] PossibleMoves();
    }
}
