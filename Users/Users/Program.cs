using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            user.Login = "John";

            var regUser = new RegisteredUser("Karl", "qwerty", "karl@gmail.com");

            var admin = new Admin()
            {
                Login = "Mike",
                Password = "1234567890",
                Email = "admin@mysevice.ru",
                Level = 3
            };

            VIPUser vip = new VIPUser()
            {
                Login = "George",
                Password = "666666",
                Email = "vip@gmail.com",
                CardNumber = 1234567890
            };

            var service = new Service("log.txt", LogStream.File, 
                user, admin, vip, regUser);

            Console.ReadKey();
            service.AddUser(new User("Kate"));

            Console.ReadKey();
            service.RemoveUser(admin);

            //foreach (var u in service)
            //    Console.WriteLine(u);

            //user.Log += x => Console.WriteLine(x);

            //user.LogMe("Проверка события");



            Console.ReadKey();
        }

        static void PrintUsers(User[] u)
        {
            Console.WriteLine("=================");

            foreach (var elem in u)
                Console.WriteLine(elem);
        }

        static void PrintRegUsers(RegisteredUser[] regs)
        {
            Console.WriteLine("=================");

            foreach (var elem in regs)
                Console.WriteLine($"Пароль: {elem.Password}. {elem}");
        }
    }
}
