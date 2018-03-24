using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration.IntegrationModels;

namespace Schedule.IntIta.Integration
{
    public interface IUserIntegration
    {
        List<User> GetUserList();
        List<User> GetUserByStr(string searchStr);

    }
}