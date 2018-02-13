﻿using System.Collections.Generic;

namespace Schedule.IntIta.DataAccess
{
    public interface IUserRepository
    {
        void Insert(User item);
        User Get(int id);
        void Update(User modifiedItem);
        void Delete(int id);
        IEnumerable<User> GetAll();
    }
}
