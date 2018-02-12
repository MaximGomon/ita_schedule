using Schedule.IntIta.Integration.Enums;

namespace Schedule.IntIta.Integration
{
    class User
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Grant[] Grants;
        public UserType UType { get; set; }

        public User() {}

        public User(string log, string e, string fn, string ln, UserType uT)
        {
            Login = log;
            Email = e;
            FirstName = fn;
            LastName = ln;
            UType = uT;
        }

        public User Create()
        {
            return new User();
        }

        public User Get(int id)
        {
            return this;
        }

        public void Update(int id, User user)
        {
            
        }

        public bool Delete(int id)
        {
            return false;
        }

        public void AddGrant(Grant grant)
        {
            for (var i = 0; i < Grants.Length; i++)
            {
                if (Grants[i] == null)
                {
                    Grants[i] = grant;
                }
            }
        }
    }
    
}
