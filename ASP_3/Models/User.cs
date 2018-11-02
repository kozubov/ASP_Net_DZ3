using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_3.Models
{
    public class User
    {
        internal object id;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }

        public User(string firstName, string lastName, string login, string password, string email, string phone)
        {

            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            Email = email;
            Phone = phone;
        }

        public void AddRole(Role role)
        {
            Role = role;
        }

        public void Renam_User(string firstName, string lastName, string login, string password, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            Email = email;
            Phone = phone;
        }
    }
}