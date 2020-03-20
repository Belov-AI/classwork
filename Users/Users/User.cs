using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public class User : IComparable<User>
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

        public int CompareTo(User other)
        {
            return this.Login.CompareTo(other.Login);
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
        private User[] users;

        public Service(params User[] u)
        {
            users = new User[u.Length];
            for (var i = 0; i < users.Length; i++)
                users[i] = u[i];
        }

        public IEnumerator GetEnumerator()
        {
            return users.GetEnumerator();
        }
    }
}
