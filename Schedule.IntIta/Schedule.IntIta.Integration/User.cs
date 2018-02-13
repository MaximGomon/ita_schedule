using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration.Enums;
using System.Collections.Generic;

namespace Schedule.IntIta.Integration
{
    public class User
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserType UserType { get; set; }
        public Grant[] Grants;

    }
    
}
