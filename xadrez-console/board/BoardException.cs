using System;

namespace board
{
    class BoardException : Exception
    {
        public BoardException(string error) : base(error) { }
    }
}
