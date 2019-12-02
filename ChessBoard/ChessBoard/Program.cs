using System;


namespace Chessboard
{
    class Program
    {
        static void Main()
        {
            int boardSize = 1;

            while (true)
            {

                Console.WriteLine("Введите размер доски (от 1 до 80). Нажмите Enter для выхода");
                string str = Console.ReadLine();
                if (str == "")
                    break;

                if (int.TryParse(str, out boardSize))
                    if (1 <= boardSize && boardSize <= 80)
                        PrintBoard(boardSize);
                    else
                        Console.WriteLine("Размер вне диапазона");
                else
                {
                    Console.WriteLine("Ошибка ввода");
                }

                Console.WriteLine();
            }

            //Здесь ввод размера доски.
            //оформите его в виде бесконечного цикла с проверкой,
            //что 1<= boardSize <= 80
            //и предложением повторного ввода, если условие не выполняется
            //Предусмотрите отказ от ввода (с последующим завершением программы).

            

            //PrintSquare(ConsoleColor.Yellow);

            //Console.ReadKey();
        }

        static void PrintBoard(int size)
        {
            var board = new bool[size, size];

            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                    if ((i + j) % 2 == 0)
                        board[i, j] = true;
                    else
                        board[i, j] = false;

            int counter = 0;

            foreach (var cell in board)
            {
                if (cell)
                    PrintSquare(ConsoleColor.White);
                else
                    PrintSquare(ConsoleColor.DarkBlue);

                counter++;

                if (counter == size)
                {
                    counter = 0;
                    Console.WriteLine();
                }
            }


            //написать метод печати шахматной доски размера (size x size)
        }

        /// <summary>
        /// Печать квадрата нужного цвета
        /// </summary>
        /// <param name="color">Цвет квадрата</param>
        static void PrintSquare(ConsoleColor color)
        {
            const char square = (char)0x2588;

            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(square);
            Console.ForegroundColor = defaultColor;
        }
    }
}
