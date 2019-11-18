using System;

namespace JapaneseCalendar
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                string str;

                Console.WriteLine("Input the year number (press Enter to exit)");
                str = Console.ReadLine();
                if (str == string.Empty)
                    break;
                
                int year;

                if (!int.TryParse(str, out year))
                {
                    Console.WriteLine("Input error");
                    continue;
                }

                int numberOfYear;

                if (year >= 1984)
                    numberOfYear = (year - 1984) % 60;
                else
                    numberOfYear = (year - 1984) % 60 + 60;

                Console.WriteLine("{0} is the year of {1} {2}.",
                    year, GetColor(numberOfYear / 12),
                    GetAnimal(numberOfYear % 12));

                Console.WriteLine();
            }
        }

        static string GetColor(int number)
        {
            switch (number)
            {
                case 0:
                    return "green";
                case 1 :
                    return "red";
                case 2:
                    return "yellow";
                case 3:
                    return "white";
                default:
                    return "black";
            }
        }

        static string GetAnimal(int number)
        {
            switch (number)
            {
                case 0:
                    return "rat";
                case 1:
                    return "cow";
                case 2:
                    return "tiger";
                case 3:
                    return "hare";
                case 4:
                    return "dragon";
                case 5:
                    return "snake";
                case 6:
                    return "horse";
                case 7:
                    return "sheep";
                case 8:
                    return "monkey";
                case 9:
                    return "han";
                case 10:
                    return "dog";
                default:
                    return "pig";
            }
        }
    }
}
