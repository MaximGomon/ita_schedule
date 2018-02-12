using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Integration
{
    interface IUser
    {
        bool CreateNewUser();
        User Get(int id);
        void Update(int id, User user);
        void Delete(int id);
        void AddGrant(Grant grant);
    }
}
