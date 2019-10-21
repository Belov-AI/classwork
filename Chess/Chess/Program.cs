using System;

namespace Chess
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите позицию белого ферзя");
            var posWhite = Console.ReadLine().ToLower();

            Console.WriteLine("Введите позицию черного короля");
            var posBlack = Console.ReadLine().ToLower();

            Console.WriteLine("Введите ход белого ферзя");
            var moveWhite = Console.ReadLine().ToLower();

            Console.WriteLine("Возможность хода: {0}",
                IsQueenCanMove(posWhite, moveWhite) &&
                !IsKingCanMove(posBlack, moveWhite));
            
            

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

            return (startColumn == endColumn || startRow == endRow ||
                Math.Abs(startColumn - endColumn) == Math.Abs(startRow - endRow)) 
                && start != end;
        }

        static bool IsKingCanMove(string start, string end)
        {
            int startColumn, startRow, endColumn, endRow;

            DecodePosition(start, out startColumn, out startRow);
            DecodePosition(end, out endColumn, out endRow);

            return Math.Abs(startRow - endRow) <= 1 &&
                Math.Abs(startColumn - endColumn) <= 1 && start != end;
        }
        
    }
}
