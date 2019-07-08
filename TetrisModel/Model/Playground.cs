using System;

namespace TetrisGameModel
{

    public class Playground
    {
        public int numberOfRows { get; }
        public int numberOfColumns { get; }
        public Cell[,] Playgroundarray { get; }
        //  TODO:create own value type cell

        public Playground(int numberOfRows, int numberOfColumns)
        {
            numberOfRows = 22;
            numberOfColumns = 10;

            Cell[,] playgroundarray = CreateArrayofCells();
            Playgroundarray = playgroundarray;
        }
        void PutFigure(Figure figure)
        {
            if (figure.Width <= numberOfRows && figure.Height <= numberOfColumns)
            {
                for (int i = 0; i < figure.Width; i++)
                {
                    for (int j = 0; j <= figure.Height; j++)
                    {
                        Cell playgroundCell = Playgroundarray[i, j];
                        Cell figureCell = figure.Figurearray[i][j];
                        if (figureCell != Cell.Empty && playgroundCell != Cell.Empty)
                        {
                            throw new ArgumentException();
                        }
                    }
                }

                for (int i = 0; i < figure.Width; i++)
                {
                    for (int j = 0; j <= figure.Height; j++)
                    {
                        Cell figureCell = figure.Figurearray[i][j];
                        if (figureCell != Cell.Empty)
                        {
                            Playgroundarray[i, j] = Cell.WithFlyingFigure;
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException();
            }
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



