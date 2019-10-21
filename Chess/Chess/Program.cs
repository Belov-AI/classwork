using System;

namespace Chess
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите позицию белой фигуры");
            var posWhite = Console.ReadLine().ToLower();
            //int x, y;
            //DecodePosition(posWhite, out x, out y);
            //Console.WriteLine("Вертикаль: {0}, горизонталь {1}", x, y);

            Console.WriteLine("Введите ход белой фигуры");
            var moveWhite = Console.ReadLine().ToLower();

            Console.WriteLine(IsQueenCanMove(posWhite, moveWhite));

            Console.ReadKey();
        }

        static void DecodePosition(string position, 
            out int column, out int row)
        {
            column = (int)position[0] - 0x60;
            row = (int)position[1] - 0x30;
        }

        static bool IsQueenCanMove(string start, string end)
        {
            int startColumn, startRow, endColumn, endRow;

            DecodePosition(start, out startColumn, out startRow);
            DecodePosition(end, out endColumn, out endRow);

            return startColumn == endColumn || startRow == endRow ||
                Math.Abs(startColumn - endColumn) == Math.Abs(startRow - endRow);
        }

        
    }
}
