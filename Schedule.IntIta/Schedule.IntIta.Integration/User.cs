using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration.Enums;
using System.Collections.Generic;

namespace Schedule.IntIta.Integration
{
    class User : IUser
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserType UType { get; set; }
        public List<Grant> Grants;

        public virtual Teacher Teacher { get; set; }


        public User() {}
        
        public User(string log, string e,string pass, string fn, string ln, UserType uT)
        {
            Login = log;
            Email = e;
            Password = pass;
            FirstName = fn;
            LastName = ln;
            UType = uT;
            Grants = new List<Grant>();
        }

        public bool CreateNewUser()
        {
            return false;
        }

        public User Get(int id)
        {
            return this;
        }

        public void Update(int id, User user)
        {
            this.Login = user.Login;
            this.Email = user.Email;
            this.FirstName = user.FirstName;
            this.Grants = user.Grants;
            this.LastName = user.LastName;
            
        }

        public void Delete(int id)
        {
            
        }

        public void AddGrant(Grant grant)
        {
            Grants.Add(grant);
        }
    }
    
}
