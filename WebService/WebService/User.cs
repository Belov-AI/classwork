using System;


namespace WebService
{
    public class User
    {
        public string Login;
        public string Password;
        private int userID;


        public void PrintInfo()
        {
            Console.WriteLine($"Пользователь {Login}. Пароль {Password}");
            //Console.WriteLine("Пользователь {0}. Пароль {1}", Login, Password);
        }
    }

    public class Service
    {
        string Protocol;
    }
}
