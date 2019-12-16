using System;
using System.IO;

namespace FilesAndDirectories
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите имя файла:");
            var fileName = Console.ReadLine();

            FileStream file;

            if (!File.Exists(fileName))
                file = File.Create(fileName);
            else
                file = new FileStream(fileName, FileMode.Open);


            if (File.Exists(file.Name))
                Console.WriteLine($"Файл {GetShortFileName(file)} существует");
            else
                Console.WriteLine($"Файл {GetShortFileName(file)} не существует");

            var anotherFile = new FileInfo("story.txt");
            Console.WriteLine("Создали объект файла " + anotherFile.Name);

            file.Close();
            var text = File.ReadAllLines(file.Name);
            
            Console.WriteLine();

            foreach (var line in text)
                Console.WriteLine(line);
            
            File.WriteAllText(file.Name,"To be or not to be");
            var newLines = new[] { "That is the question" };
            File.AppendAllLines(file.Name, newLines);


            Console.ReadKey();
        }

        static string GetShortFileName(FileStream file)
        {
            return file.Name.Substring(file.Name.LastIndexOf('\\')+1);
        }
    }
}
