using System;

namespace WebService
{
    class Program
    {

        static void Main()
        {
            var human = new User();
            human.Login = "Mike";
            human.Password = "12345";

            human.PrintInfo();

            Console.ReadKey();
        }
    }
}
