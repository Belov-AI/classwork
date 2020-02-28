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
            user.PrintInfo();

            var regUser = new RegisterdUser("Karl", "qwerty", "karl@gmail.com");
            //Console.WriteLine($"Логин: {regUser.Login}, пароль: {regUser.Password}, " +
            //    $"почта: {regUser.Email}");
            regUser.PrintInfo();

            var admin = new Admin()
            {
                Login = "Mike",
                Password = "1234567890",
                Email = "admin@mysevice.ru",
                Level = 3
            };

            admin.PrintInfo();
            user = admin;
            user.PrintInfo();

            VIPUser vip = new VIPUser()
            {
                Login = "George",
                Password = "666666",
                Email = "vip@gmail.com",
                CardNumber = 1234567890
            };
            vip.PrintInfo();
            user = vip;
            user.PrintInfo();

            if (user is RegisterdUser)
            {
                regUser = (RegisterdUser)user;
                regUser.PrintInfo();
            }
            else
                Console.WriteLine("Не удалось преобразовать тип");

            admin = user as Admin;
            if (admin != null)
                admin.PrintInfo();
            else
                Console.WriteLine("Не удалось преобразовать тип");


            

            //var obj = new Object();
            //Console.WriteLine(user);

            Console.ReadKey();
        }
    }
}
