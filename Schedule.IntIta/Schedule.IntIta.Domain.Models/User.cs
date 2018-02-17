using Schedule.IntIta.Domain.Models.Enumerations;

namespace Schedule.IntIta.Domain.Models
{
    public class User : IdEntity
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
