using System;
using System.Text;
using System.Collections.Generic;
namespace TestPlayground
{
    class Program
    {
        static int Width = 1000;
        static int Height = 200;
        static void Main2(string[] args)
        {
            // временная песочница
            // 1)
            // нужно создать массив из 5 интов, чтобы содержимое было 1, 2, 3, 4, 5
            int[] arrayA = { 1, 2, 3, 4, 5 };
            int[] arrayB = new int[] { 1, 2, 3, 4, 5 };
            var arrayC = new int[] { 1, 2, 3, 4, 5 };
            int[] arrayD = new int[5];
            arrayD[0] = 1;
            arrayD[1] = 2;
            arrayD[2] = 3;
            arrayD[3] = 4;
            arrayD[4] = 5;

            // 2)
            // нужно создать массив интов, чтобы размер был равен Width (переменной), а значения 1, 2, 3, ... Width - как?

            var arrayE = new int[Width];
            for (int j = 0; j < arrayE.Length; j += 1)
            {
                arrayE[j] = j + 1;
                Console.Write(arrayE[j]);
            }

            // 3)
            // нужно создать массив массивов интов, чтобы размер был равен
            // Width, и в каждый элемент положить массив интов размером Height,
            // в каждый элемент новый
            var arrayK = new int[Width][];
            var arrayL = new int[Height];
            for (int j = 0; j < arrayK.Length; j += 1)
            {
                arrayK[j] = arrayL;


            }


            // 4)
            // нужно создать массив массивов интов, чтобы размер был равен
            // Width, и в каждый элемент положить массив интов размером Height,
            // в каждый элемент новый
            var arrayM = new int[Width][];

            for (int j = 0; j < arrayK.Length; j += 1)
            {
                var arrayN = new int[Height];
                arrayM[j] = arrayN;

            }

        }



        static void Main1(string[] args)
        {
            int[] a = new int[991];//x-y+1

            /* for (int i = 0; i < 991; i++)
             {
                 int c = i + 10;
                 a[i] = c;
             }*/
            /* for (int c = 10; c <= 1000; c++)
            {
                int i = c - 10;
                a[i] = c;
            }*/
            for (int i = 0, c = 10; c <= 11; i++, c++)
            {
                // a[i] = c; мы обращаемся к индексу массива и записываем
                // значением которое должно быть в элементе массива,
                // в этот элемент
                Console.WriteLine(c);
            }

            for (int i = 0; i < 991; i++)
            {
                Console.WriteLine(a[i]);//вывод на консоль 
            }

            Console.ReadKey();
            int[,] arrays = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };


            //    foreach (int subArray in arrays)
            //    {
            //        foreach (int i in subArray)
            //        {
            //            Console.Write(i);
            //        }
            //    }



            //    for (int j = 0; j < arrays.Length; j += 1)
            //    {
            //        for (int k = 0; k < arrays[j].Length; k += 1)
            //        {
            //            Console.Write(arrays[j][k]);
            //        }
            //    }



            /* int a [c] = что тут писать?

            i=c-10
            теперь нужно каждому элементу присвоить то значение, которое там должно быть в реальности
            for (int c= 10; (c >= 10) && ( c <= 1000); i++)*/
            /* for (int i = 0; i < 991; i++)
                        {
                            Console.WriteLine(a[i]);
                        }*/

        }
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/comparison-between-properties-and-indexers
        static void Main(string[] args)
        {
            var colors = new Color[,]//var colors определена тут
            {
                { Color.Red, Color.Green, Color.Red },
                { Color.Yellow, Color.Green, Color.Red }
            };
            var nr = new NeverRed(colors);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(nr[i, j] + " ");
                    //Console.Write(nr.GetColor(i, j) + " ");
                Console.WriteLine();
            }



            IncapsulationTest test = new IncapsulationTest();
            //test.NumericProperty = 100; // не компилируется
           // test.ArrayProperty = null; // тоже не компилируется
            // но!
            test.ArrayProperty[0] = 500; // компилируется!
        }
    }

    class IncapsulationTest
    {
        public int NumericProperty { get; } // не требует инкапсуляции
        public int[] ArrayProperty { get; } // требует инкапцуляции
        public IncapsulationTest()
        {
            NumericProperty = 100;
            ArrayProperty = new[] { 1, 2, 3, 4, 5 };
        }
    }

    enum Color
    {
        Red,
        Yellow,
        Green
    }

    // покамест обыкновенный класс
    class NeverRed
    {
        public NeverRed(Color[,] colors)//var colors почему когда мы кладем эту функцию в другой класс 
            //и там в аргумент кладем var colors compiler  не ругается
        {
            originalColors = colors;
        }

        // вот это обыкновенная функция
        public Color GetColor(int i, int j)
        {
            Color originalColor = originalColors[i, j];//это индексация массива
            if (originalColor == Color.Red)
                return Color.Yellow;
            else
                return originalColor;
        }

        // а это индексатор
        public Color this[int i, int j]//вопрос только в слове this
        {//Console.Write(nr.GetColor(i, j) + " ");
            get
            {
                Color originalColor = originalColors[i, j];//это индексация массива
                if (originalColor == Color.Red)
                    return Color.Yellow;
                else
                    return originalColor;
            }
        }

        Color[,] originalColors;
    }

    class Encryptor
    {
        public Encryptor(List<char> capitalLetters, List<char> smallLetters)
        {
            // полю capitalLetters присваиваем значение параметра capitalLetters
            // зачем ? если не присвоить, ну так откуда мы возьмём потом значение 
            // capitalLetters? не заставлять же юзера в каждом вызове Encrypt
            // передавать ещё и списки?
            // огласовки и буквы
            // ну нужно же делать логические эвересты
            //ну в иврите мама пишеться как мм

            this.capitalLetters = capitalLetters;
            this.smallLetters = smallLetters;
        }

        public string Encrypt(string line)//read stringbuilder in ms docs
        {

            var builder = new StringBuilder();
            foreach (char symbol in line)
            {
                char encryptedsymbol = EncryptSymbol(symbol);
                builder.Append(encryptedsymbol);
            }
            // обходим циклом foreach строку
            // нужно закодировать каждый символ и добавить к builder'у

            return builder.ToString();
        }

        public string Decrypt(string line)
        {
            var builder = new StringBuilder();
            foreach (char symbol in line)
            {
                char decryptedsymbol = DecryptSymbol(symbol);
                builder.Append(decryptedsymbol);
            }

            return builder.ToString();
        }


        (int listIndex, int letterIndex) MatchingLetters(char symbol)
        //нам нужно объявить метод и вызвать его, который бы
        //а) определял индекс буквы в алфавите, по нашему - в списке
        //b) записывал бы букву как 2 числа, где первое - номер списка, 
        //а второе - номер по порядку в алфавите
        {
            //у параметра тип char 
            //возвращаемое значение записано в переменную и ему присвоенно через === значение 1
            int LettersinNumbersBig = capitalLetters.IndexOf(symbol);
            if (LettersinNumbersBig != -1)//нашли большую
            {
                return (listIndex: 0, letterIndex: LettersinNumbersBig);//нашли среди больших
            }

            int LettersinNumbersSmall = smallLetters.IndexOf(symbol);//пошли среди маленьких
            if (LettersinNumbersSmall != -1)//нашли среди маленьких
            {
                return (listIndex: 1, letterIndex: LettersinNumbersSmall);//нашли среди маленьких
            }

            return (listIndex: -1, letterIndex: -1); //вернули значение -1
                                                     //я бы в строке 43 вернул как номер списка -1 тоже
                                                     //потому что в 1 списке ж буквы нет
        }

        /* - старая логика
            int LettersinNumbersBig = capitalLetters.IndexOf(symbol);
            if (LettersinNumbersBig == -1)//не нашли большую
            {
                int LettersinNumbersSmall = smallLetters.IndexOf(symbol);//пошли среди маленьких
                if (LettersinNumbersSmall== -1)//не нашли среди маленьких
                {
                    return (listIndex: -1, letterIndex: -1); //вернули значение -1
                }
                else
                {
                    return (listIndex: 1, letterIndex: LettersinNumbersSmall);//нашли среди маленьких
                } 
            }
            else
            {
                return (listIndex: 0, letterIndex: LettersinNumbersBig);//нашли среди больших
            }            
         */

        // даны номер списка и номер буквы в нём, вернуть саму букву
        // номер спискаи нмер буквы определяются как в MatchingLetters
        char LetterCodeToLetter(int listIndex, int letterIndex)
        {
            if (listIndex == 0)
            {
                return capitalLetters[letterIndex];
            }

            if (listIndex == 1)
            {
                return smallLetters[letterIndex];
            }

            // если мы дошли сюда, listIndex неправильный, бросаем исключение
            throw new ArgumentException("listIndex must be 0 or 1");
            // Console.WriteLine("File is empty");
            //return 'n';line 62-63 are technical solution only
            //это мы возращаем букву по индексам
        }
        //не буква может быть несколько вариантов: пробел, 
        //символ(запятая или скобки), отсутствие текста, иероглиф 
        //(слово),эмоджи  где эти варианты учитываются?
        char EncryptSymbol(char symbol)
        {
            (int listIndex, int letterIndex) = MatchingLetters(symbol);//функция возвращает кортеж.тупл
            if (letterIndex == -1)
                return symbol;//не буква
                              //else
                              //{
            letterIndex += 1;
            if (letterIndex >= capitalLetters.Count)
                //вручную переполнение индекса (если он достиг края массива)
                letterIndex = 0;
            //char encryptedsymbol = LetterCodeToLetter(listIndex,  letterIndex);
            //return encryptedsymbol;
            return LetterCodeToLetter(listIndex, letterIndex);
            //}
        }

        char DecryptSymbol(char symbol)//функция которая расшифровывает буквенный шифр в виде одиночных символов
        {
            (int listIndex, int letterIndex) = MatchingLetters(symbol);// кортеж информирует из какого списка символ и какой его номер в списке
            if (listIndex == -1)//если символ не присутствует ни в одном из списков (б. и м. букв)б. с точкой звучит эпично! а то!целую <3 бери крысу - дальше ты :-*
                return symbol;//возвращает символ нетронутым

            letterIndex -= 1;//отнимаем от индекса еденицу
            if (letterIndex == -1)//затыкзатык- НЕТУ ЗАТЫКА!
                letterIndex = capitalLetters.Count - 1;//
            return LetterCodeToLetter(listIndex, letterIndex);
            //
        }

        // поля обычно размещают либо все внизу, либо все вверху
        List<char> capitalLetters;
        List<char> smallLetters;
    }
}




