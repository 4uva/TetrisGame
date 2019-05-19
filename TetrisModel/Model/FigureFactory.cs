using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisGameModel
{
    class FigureFactory
    {
        Cell Empty { get; }
        Cell Occupied { get; }
        public int width { get; }
        public int heigh { get; }
    }
}
