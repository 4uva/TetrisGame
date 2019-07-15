using System;

namespace TetrisGameModel
{

    public class Playground
    {
        public int numberOfRows { get; }
        public int numberOfColumns { get; }
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
            if (figure.Width > numberOfRows || figure.Height > numberOfColumns)
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
            numberOfRows = 22;
            numberOfColumns = 10;

            Cell[,] playgroundarray = CreateArrayofCells();
            Playgroundarray = playgroundarray;
        }
        //public Color this[int i, int j]//вопрос только в слове this
        //{//Console.Write(nr.GetColor(i, j) + " ");
        //    get
        //    {
        //        Color originalColor = originalColors[i, j];//это индексация массива
        //        if (originalColor == Color.Red)
        //            return Color.Yellow;
        //        else
        //            return originalColor;
        //    }
        //}

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




