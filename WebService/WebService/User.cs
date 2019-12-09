using System;

namespace WebService
{
    public class User
    {
        static public readonly string LogFileName;

        private int userID;
        private string password;

        public string Login;
       
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

        public User(string userLogin, string userPassword)
        {
            Login = userLogin;
            Password = userPassword;
            Console.WriteLine($"{DateTime.Now} - пользователь {Login} создан");
        }

        public User(string userLogin) : this(userLogin, "qwerty") { }

        public User() : this("Anonymous") { }

        static User()
        {
            LogFileName = "log_" 
                + DateTime.Now.ToShortDateString().Replace('.','-') 
                + ".txt";
        }

        ~User()
        {
            Console.WriteLine($"{DateTime.Now} - пользователь {Login} удален");
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Пользователь {Login}. Пароль {Password}");
        }
  
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
