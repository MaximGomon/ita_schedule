using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    public class SecurityGroupRepository : CrudRepository<SecurityGroup>, ISecurityGroupRepository
    {
         
    }
}