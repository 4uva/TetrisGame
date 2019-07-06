using System;
namespace TetrisGameModel
{
    public class Figure
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public Cell[][] Figurearray { get; private set; }

        public Figure(int width, int height, Cell[][] figurearray)
        {
            Width = width;
            Height = height;
            Figurearray = figurearray;
        }

        public void Rotate()// todo check cell  out or in playground
        {
            int initialWidth = Width;
            Width = Height;
            Height = initialWidth;


            Cell[][] allColumns = new Cell[Width][];//объявили создание  массива колонок

            for (int i = 0; i < allColumns.Length; i += 1)//обошли индексы  массива колонок
            {

                var column = new Cell[Height];//*создали* столбец нужной длины
                for (int j = 0; j < column.Length; j += 1)// мы обходим индексы в столбце
                {
                    int i_Old = j; //установили  начальные значения индексов  в старом массиве старого массива (горизонталь)
                    int j_Old = Height - i;//установили начальные значения индексов  в старом массиве старого массива (вертикаль)

                    column[j] = Figurearray[i_Old][j_Old];//столбец-массив выглядит как `Figurearray[i_Old]`

                    
                }
                allColumns[i] = column;
            }
            Figurearray = allColumns;
            
        }

    }
}





