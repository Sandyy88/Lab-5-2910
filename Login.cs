using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_2910
{
    public class Login
    {
        public string Username {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Login() { }
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            string s = " ";
            s += $"\n\n\tLOGIN INFO:" +
                $"\n\t\tUsername: {Username}" +
                $"\n\t\tPassword: {Password}";

            return s;
        }
    }
}
