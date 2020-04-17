using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Genealogy
{
    class Program
    {
        static Dictionary<string, string> tree = new Dictionary<string, string>();

        static void Main()
        {
            InitializeTree();

            if (tree.Count == 0)
                return;

            while (true)
            {
                Console.WriteLine("Выберите опцию:");
                Console.WriteLine("1 - основатель рода");
                Console.WriteLine("2 - ближайший общий предок");
                Console.WriteLine("0 - выход");

                int result = 0;

                if(!int.TryParse(Console.ReadLine(), out result) ||
                    result > 2 || result < 0)
                {
                    Console.WriteLine("\nВведите номер одной из перечисленных опций.");
                    continue;
                }

                switch (result)
                {
                    case 1:
                        PrintFounder();
                        break;
                    case 2:
                        Console.WriteLine("Введите имя первого человека");
                        var first = Console.ReadLine();
                        if (!IsCorrectPerson(first))
                            continue;

                        Console.WriteLine("Введите имя второго человека");
                        var second = Console.ReadLine();
                        if (!IsCorrectPerson(second))
                            continue;
                        
                        CheckAncestor(first, second);
                        break;

                    default:
                        return;                        
                }

            }
        }

        static void InitializeTree()
        {
            string filename;

            while (true)
            {
                Console.WriteLine("Введите имя файла");
                filename = Console.ReadLine();

                if (filename == "")
                    return;

                if (File.Exists(filename))
                    break;
                else
                    Console.WriteLine("Такого файла нет\n");
            }

            using(var file = new StreamReader(filename, Encoding.Default))
            {
                string line;

                while (!file.EndOfStream)
                {
                    line = file.ReadLine();
                    string[] record = line.Split(new[] { " - " }, 
                        StringSplitOptions.RemoveEmptyEntries);
                    tree[record[1]] = record[0];
                }
            }
        }

        static void PrintFounder()
        {
            foreach(var person in tree.Values)
                if (!tree.ContainsKey(person))
                {
                    Console.WriteLine($"Основатель рода - {person}.\n");
                    break;
                }
        }

        static void CheckAncestor(string a, string b)
        {
            var ancestorsA = GetAncestors(a);
            var ancestorsB = GetAncestors(b);

            if (ancestorsB.Contains(a))
                Console.WriteLine($"{a} - предок, {b} - потомок.");
            else if (ancestorsA.Contains(b))
                Console.WriteLine($"{b} - предок, {a} - потомок.");
            else
            {
                foreach(var person in ancestorsA)
                    if (ancestorsB.Contains(person))
                    {
                        Console.WriteLine($"Ближайший общий предок - {person}.\n");
                        break;
                    }
            }
        }

        static bool IsCorrectPerson(string person)
        {
            if (!(tree.ContainsKey(person) || tree.ContainsValue(person)))
            {
                Console.WriteLine($"{person} в дереве отсуствует.\n");
                return false;
            }
            else
                return true;
        }

        static List<string> GetAncestors(string person)
        {
            var result = new List<string>();

            while (tree.ContainsKey(person))
            {
                person = tree[person];
                result.Add(person);
            }

            return result;
        }
    }
}
