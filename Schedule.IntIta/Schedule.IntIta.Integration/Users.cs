using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Integration
{
    class Users
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Grant[] Grants;
    }
    
}
