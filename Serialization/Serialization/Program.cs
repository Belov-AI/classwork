using System;
using System.IO;
using System.Xml.Serialization;


namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var paul = new Person("Paul", "McCartney", 33);

            Console.WriteLine(paul);

            SaveInXML(paul, "person.xml");
            var person = LoadFromXML<Person>("person.xml");
            Console.WriteLine(person);

            var john = new Person("Jonh", "Lennon", 35);

            var theBeatles = new[] {paul, john,
                new Person("George", "Harrison", 34),
                new Person("Ringo", "Starr", 32)};

            SaveInXML(theBeatles, "band.xml");
            var band = LoadFromXML<Person[]>("band.xml");
            foreach (var musician in band)
                Console.WriteLine(musician);

            Console.ReadKey();
        }

        static void SaveInXML<T>(T obj, string fileName)
        {
            var formatter = new XmlSerializer(typeof(T));

            using(var fs = new FileStream(fileName, 
                FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(fs, obj);
                Console.WriteLine($"-> Saved {obj} in XML");
            }
        }

        static T LoadFromXML<T>(string fileName)
        {
            var formatter = new XmlSerializer(typeof(T));

            T result = default;

            if (File.Exists(fileName))
            {
                using (var fs = new FileStream(fileName,
                        FileMode.Open, FileAccess.Read))
                {
                    result = (T)formatter.Deserialize(fs);
                    Console.WriteLine($"<- Loaded {result} from XML");
                }
            }

            return result;
        }
    }
}
