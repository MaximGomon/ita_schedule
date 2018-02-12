using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Integration
{
    class User
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Grant[] Grants;

        public User() {}

        public User(string log, string e, string fn, string ln)
        {
            Login = log;
            Email = e;
            FirstName = fn;
            LastName = ln;
        }

        public User CreateUser()
        {
            return new User();
        }

        public User ReadUser(int id)
        {
            return this;
        }

        public void UpdateUser(User user, int Id)
        {
            
        }

        public bool DeleteUser(int id)
        {
            return false;
        }

    }
    
}
