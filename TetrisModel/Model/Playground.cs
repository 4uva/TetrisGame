using System;

namespace TetrisGameModel
{
    public class Playground
    {
        public int numberOfRows { get; }
        public int numberOfColumns { get; }
        public Cell[,] playgroundarray { get; }
        //  TODO:create own value type cell
        public Playground(int numberOfRows, int numberOfColumns)
        {
            numberOfRows = 22;
            numberOfColumns = 10;

            playgroundarray = CreateArrayofCells();
        }

        Cell[,] CreateArrayofCells()
        {
            Cell[,] array = new Cell[numberOfRows, numberOfColumns];

            for (int i = 0; i < numberOfRows; i++)
                for (int j = 0; j < numberOfColumns; j++)
                {
                    array[i, j] = Cell.Empty;
                }
            return array;
        }

    }
}


