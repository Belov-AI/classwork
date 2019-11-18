using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число строк");
            int numberOfRows = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число столбцов");
            int numberOfColumns = int.Parse(Console.ReadLine());

            var matrix = new int[numberOfRows, numberOfColumns];

            for (var i = 0; i < numberOfRows; i++)
                for (var j = 0; j < numberOfColumns; j++)
                {
                    Console.WriteLine("Введите число");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }

            Console.WriteLine();

            for (var i = 0; i < numberOfRows; i++)
            {
                for (var j = 0; j < numberOfColumns; j++)
                    Console.Write("{0,3:G} ", matrix[i, j]);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
