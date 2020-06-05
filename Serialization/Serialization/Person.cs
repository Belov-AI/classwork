using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Person
    {
        public string Name;
        public string Surname;

        [NonSerialized]
        public int Age;

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public Person() : this("John", "Doe", 0) { }

        public override string ToString()
        {
            return $"{Name} {Surname}, возраст {Age}";
        }
    }
}
