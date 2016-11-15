using System.Collections.Generic;
using System.Linq;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Implementations
{
    public class SubjectBl : CrudBll<ISubjectRepository, Subject>, ISubjectBl
    {
        public SubjectBl(ISubjectRepository repository) : base(repository)
        {
        }

        ////get all entities from db by type
        //public new ICollection<Subject> GetAll()
        //{
        //    return Repository.GetAllEntities().ToList();
        //}
    }
}
