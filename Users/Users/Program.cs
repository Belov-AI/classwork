﻿using System;
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

            {
                //vip.PrintInfo();
                //user = vip;
                //user.PrintInfo();

                //if (user is RegisterdUser)
                //{
                //    regUser = (RegisterdUser)user;
                //    regUser.PrintInfo();
                //}
                //else
                //    Console.WriteLine("Не удалось преобразовать тип");

                //admin = user as Admin;
                //if (admin != null)
                //    admin.PrintInfo();
                //else
                //    Console.WriteLine("Не удалось преобразовать тип");


                //User[] users = new[] { user, admin, regUser, vip };

                //Array.Sort(users);
                //Array.Reverse(users);

                //PrintUsers(users);

                //RegisteredUser[] regUsers = new[] { admin, regUser, vip };
                //PrintRegUsers(regUsers);
                //Array.Sort(regUsers);
                //PrintRegUsers(regUsers);

                //var comparerByPassword = new RegUsersComparerByPassword();
                //Array.Sort(regUsers, comparerByPassword);
                //PrintRegUsers(regUsers);

                //Console.WriteLine();
            }

            var service = new Service(user, admin, vip, regUser);

            service.Users.Add(new User("Kate"));
            service.Users.Insert(1, new User("Lilibeth"));
            service.Users.Remove(admin);

            service.Users.Sort();
            service.Users.Reverse();

            foreach (var u in service)
                Console.WriteLine(u);

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
