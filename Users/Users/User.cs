using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class User
    {
        public string Login;

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
    }

    public class RegisterdUser : User
    {
        public string Email;
        private string password;

        public RegisterdUser(string login, string pass, string email) : base(login)
        {
            Email = email;
            Password = pass;
        }

        public RegisterdUser() : this("anonimous", "123456", "") { }

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

    public class Admin : RegisterdUser
    {
        public int Level;
    }

    public class VIPUser : RegisterdUser
    {
        public ulong CardNumber;
    }
}
