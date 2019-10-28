using System;

namespace DayOfWeek
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите название дня недели");
            var day = Console.ReadLine().ToLower();

            switch (day)
            {
                case "понедельник":
                    Console.WriteLine("Начало рабочей недели");
                    break;
                case "вторник":
                case "среда":
                case "четверг":
                    Console.WriteLine("Середина рабочей недели");
                    break;
                case "пятница":
                    Console.WriteLine("Конец рабочей недели");
                    break;
                case "суббота":
                case "воскресенье":
                    Console.WriteLine("Выходной");
                    break;
                default:
                    Console.WriteLine("Такого дня недели нет");
                    break;
            }

            Console.ReadKey();
        }
    }
}
