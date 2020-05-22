using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Users
{
    public class User : IComparable<User>
    {
        public string Login;

        public event Action<string> Log;

        public User(string login)
        {
            Login = login;
        }

        public User() : this("anonimous") { }
        
        public virtual void PrintInfo()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Пользователь {Login}";
        }

        public int CompareTo(User other)
        {
            return this.Login.CompareTo(other.Login);
        }

        public void LogMe(string message)
        {
            if (Log != null)
                Log(message);
        }
    }

    public class RegisteredUser : User
    {
        public string Email;
        private string password;

        public RegisteredUser(string login, string pass, string email) : base(login)
        {
            Email = email;
            Password = pass;
        }

        public RegisteredUser() : this("anonimous", "123456", "") { }

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length > 5)
                    password = value;
                else
                    Console.WriteLine($"{value}: Пароль дожен быть не менее 6 символов");
            }
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"{base.ToString()}. Email: {Email}");
        }

    }

    public class Admin : RegisteredUser
    {
        public int Level;
    }

    public class VIPUser : RegisteredUser
    {
        public ulong CardNumber;
    }

    public class RegUsersComparerByPassword : IComparer<RegisteredUser>
    {
        public int Compare(RegisteredUser x, RegisteredUser y)
        {
            return x.Password.CompareTo(y.Password);
        }
    }

    public class Service : IEnumerable
    {
        private List<User> users;
        private Logger logger;

        public Service(string logFile, LogStream stream, params User[] u)
        {
            logger = new Logger(logFile, stream);
            logger.Register("служба запущена");

            users = new List<User>(u);

            foreach(var user in users)
            {
                user.Log += logger.Register;
                user.LogMe($"присоединился пользователь {user.Login}");
            }
        }

        ~Service()
        {
            logger.Register("служба остановлена");
        }

        public IEnumerator GetEnumerator()
        {
            return users.GetEnumerator();
        }

        public void AddUser(User user)
        {
            users.Add(user);
            user.Log += logger.Register;
            user.LogMe($"присоединился пользователь {user.Login}");
        }

        public void RemoveUser(User user)
        {
            user.LogMe($"отсоединился пользователь {user.Login}");
            user.Log -= logger.Register;
            users.Remove(user);
        }
    }

    public class Logger
    {
        private LogStream logStream;
        private string logFileName;

        public Logger(string fileName, LogStream stream)
        {
            logFileName = fileName;
            logStream = stream;
        }

        public void Register(string message)
        {
            if (logStream == LogStream.Console)
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} {message}");
            else
                using(var file = new StreamWriter(logFileName, true))
                {
                    file.WriteLine($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()} {message}");
                }
        }
    }

    public enum LogStream { Console, File}
}
