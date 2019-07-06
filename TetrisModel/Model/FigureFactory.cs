using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisGameModel
{
    // Дизайн:
    // 1. Класс FigureFactory отвечает за заполнение клеток в
    //    создаваемых фигурах
    // 2. Класс FigureFactory не требует от вызывающего кода
    //    знания клеток фигур, это знание - ответственность
    //    класса FigureFactory
    // 3. Клетки являются энумами и как таковые не требуют своего
    //    создания: мы можеми просто пользоваться литералами энума
    // 4. Клетки будущей фигуры в каком-то виде хранятся в поле
    //    FigureFactory
    public class FigureFactory
    {
        public Figure CreateIFigure()
        {
            Cell[][] array = new Cell[1][];
            array[0] = new Cell[] { Cell.Occupied, Cell.Occupied, Cell.Occupied, Cell.Occupied };

            Figure figure = new Figure(1, 4, array);
            return figure;
        }
        public Figure CreateQFigure()
        {
            Cell[][] array = new Cell[2][];
            array[0] = new Cell[] { Cell.Occupied, Cell.Occupied };       
            array[1] = new Cell[] { Cell.Occupied, Cell.Occupied }; 

            Figure figure = new Figure(2, 2, array);
            return figure;
        }
        public Figure CreateZFigure()
        {
            Cell[][] array = new Cell[2][];
            array[0] = new Cell[] { Cell.Occupied, Cell.Occupied, Cell.Empty };
            array[1] = new Cell[] { Cell.Empty, Cell.Occupied, Cell.Occupied };

            Figure figure = new Figure(3, 2, array);
            return figure;
        }
        public Figure CreateSFigure()
        {
            Cell[][] array = new Cell[2][];
            array[0] = new Cell[] { Cell.Empty, Cell.Occupied, Cell.Occupied };
            array[1] = new Cell[] { Cell.Occupied, Cell.Occupied, Cell.Empty };

            Figure figure = new Figure(3, 2, array);
            return figure;
        }

        public Figure CreateTFigure()
        {
            Cell[][] array = new Cell[2][];
            array[0] = new Cell[] { Cell.Empty, Cell.Occupied, Cell.Empty };
            array[1] = new Cell[] { Cell.Occupied, Cell.Occupied, Cell.Occupied };

            Figure figure = new Figure(3, 2, array);
            return figure;
        }
        public Figure CreateJFigure()
        {
            Cell[][] array = new Cell[2][];
            array[0] = new Cell[] { Cell.Empty, Cell.Empty, Cell.Occupied };
            array[1] = new Cell[] { Cell.Occupied, Cell.Occupied, Cell.Occupied };

            Figure figure = new Figure( 2, 3, array);
            return figure;
        }
        public Figure CreateLFigure()
        {
            Cell[][] array = new Cell[2][];
            array[0] = new Cell[] { Cell.Occupied, Cell.Occupied, Cell.Occupied };       
            array[1] = new Cell[] {  Cell.Empty, Cell.Empty,Cell.Occupied, }; 

            Figure figure = new Figure(2, 3, array);
            return figure;
        }
    }
}

