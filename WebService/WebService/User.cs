using System;

namespace WebService
{
    public class User
    {
        public string Login;

        private string password;
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                if (value.Length > 5)
                    password = value;
                else
                    Console.WriteLine(
                        "Длина пароля должа быть не менее 6 знаков");
            }
        }

        private int userID;


        public void PrintInfo()
        {
            Console.WriteLine($"Пользователь {Login}. Пароль {Password}");
            //Console.WriteLine("Пользователь {0}. Пароль {1}", Login, Password);
        }

        //public void SetPassword(string newPassword)
        //{
        //    if (newPassword.Length > 5)
        //        Password = newPassword;
        //    else
        //        Console.WriteLine(
        //            "Длина пароля должа быть не менее 6 знаков");
        //}
    }

    public static class Service
    {
        static string Protocol = "TCP/IP";

        static int usercount = 10;

        private static int numerOfUsers = 0;

        public static int NumberOfUsers
        {
            get
            {
                return numerOfUsers;
            }
        }

        private static User[] users = new User[usercount];
        public static User[] Users
        {
            get
            {
                return users;
            }
        }

        public static void AddUser(User person)
        {
            Users[numerOfUsers] = person;
            numerOfUsers++;
        }

    }
}
