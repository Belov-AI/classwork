using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Foootball
{
    class Program
    {
        static void Main()
        {
            var champions = new Dictionary<string, int>();

            using (var file = new StreamReader("football.txt", Encoding.Default))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    var key = line.Split('\t')[1];

                    if (champions.ContainsKey(key))
                        champions[key]++;
                    else
                        champions[key] = 1;
                }
            }

            var teams = champions.Keys.ToList();
            teams.Sort();

            foreach(var team in teams)
                Console.WriteLine($"{team} - {champions[team]}");

            //foreach (var elem in champions)
            //    Console.WriteLine($"{elem.Key} - {elem.Value}");

            Console.ReadKey();
        }
    }
}
