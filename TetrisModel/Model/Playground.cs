using System;

//ToDo
// в том, что у нас есть в фигуре клетки -Occupied 
// в  и в Playground Occupied
// а вот когда фигура на доске, то мы устанавливаем
// вместо ее клеток Occupied
// в клетки Playground клетки withFlyingFigure
// 2) PutFigure invocation playground occupied cells will change to empty

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
                        Cell cellEmpty = Playgroundarray[i, j];
                        if (cellEmpty != Cell.Empty)
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
                            figureCell = Cell.WithFlyingFigure;
                            Playgroundarray[i, j] = figureCell;
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



