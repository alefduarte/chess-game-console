using System;
using board;

namespace chess
{
    class ChessPosition
    {
        public char Column { get; set; }
        public int Row { get; set; }

        public ChessPosition(char column, int row)
        {
            Column = column;
            Row = row;
        }

        public Position ToPosition()
        {
            return new Position(8 - Row, char.ToUpper(Column) - 'A');
        }

        public override string ToString() => "" + Column + Row;
    }
}
