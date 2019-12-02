using System;

namespace WebService
{
    class Program
    {

        static void Main()
        {
            var human = new User();
            human.Login = "Mike";
            human.Password = "123456";
            //human.SetPassword("123456");

            human.PrintInfo();

            human.Password = "abc";
            //human.SetPassword("abc");

            human.PrintInfo();

            //Service.Users[0] = human;
            //Service.NumberOfUsers++;

            Service.AddUser(human);

            //Service.Users[1] = new User() {
            //    Login = "Kate", Password = "qwerty" };
            //Service.NumberOfUsers++;

            Service.AddUser(new User()
            {
                Login = "Kate",
                Password = "qwerty"
            });

            Service.AddUser(new User()
            {
                Login = "Nick",
                Password = "password"
            });

            Console.WriteLine();
            for (var i = 0; i < Service.NumberOfUsers; i++)
                Service.Users[i].PrintInfo();


            Console.ReadKey();
        }
    }
}
