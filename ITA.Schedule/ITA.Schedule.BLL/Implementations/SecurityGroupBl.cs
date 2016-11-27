using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Implementations
{
    public class SecurityGroupBl : CrudBll<ISecurityGroupRepository, SecurityGroup>, ISecurityGroupBl
    {
        public SecurityGroupBl(ISecurityGroupRepository repository) : base(repository)
        {
        }
    }
}