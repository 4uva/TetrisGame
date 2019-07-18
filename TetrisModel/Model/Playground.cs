using System;

namespace TetrisGameModel
{

    public class Playground
    {
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        public Cell[,] Playgroundarray { get; }
        Figure figureOnPlayGround;
        //  TODO:create own value type cell

        Cell this[int i, int j]
        {
            get
            {
                Figure figure = figureOnPlayGround;
                Cell playgroundCell = Playgroundarray[i, j];
                Cell figureCell = figure.Figurearray[i][j];
                if (figureCell != Cell.Empty)
                {
                    return Cell.WithFlyingFigure;
                }
                else
                {
                    return playgroundCell;
                }
            }
        }

        void PutFigure(Figure figure)
        {
            //figure height & width < playground size
            if (figure.Width > NumberOfRows || figure.Height > NumberOfColumns)
                throw new ArgumentException();

            //figure puts itself with its occupied or 
            //flying cell on occupied cells of playground
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
            figureOnPlayGround = figure;
        }

        public Playground(int numberOfRows, int numberOfColumns)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;

            Cell[,] playgroundarray = CreateArrayofCells();
            Playgroundarray = playgroundarray;
        }

        Cell[,] CreateArrayofCells()
        {
            Cell[,] array = new Cell[NumberOfRows, NumberOfColumns];

            for (int i = 0; i < NumberOfRows; i++)
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    array[i, j] = Cell.Empty;
                }
            return array;
        }
    }
}




