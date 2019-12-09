using System;

namespace WebService
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine(User.LogFileName);
            
            var human = new User("Mike", "123456");

            human.PrintInfo();
            
            human.Password = "abc";
            human.PrintInfo();
            Service.AddUser(human);

            Service.AddUser(new User("Kate"));

            var smbd = new User();
            Service.AddUser(smbd);

            Console.WriteLine();
            for (var i = 0; i < Service.NumberOfUsers; i++)
                Service.Users[i].PrintInfo();

            Console.ReadKey();
        }
    }
}
