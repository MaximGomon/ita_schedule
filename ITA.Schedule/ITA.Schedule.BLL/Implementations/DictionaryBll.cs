using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity;

namespace ITA.Schedule.BLL.Implementations
{
    public class DictionaryBll<TDEntity> : CrudBll<DictionaryRepository<TDEntity>, TDEntity>,
        IDictionaryRepository<TDEntity> where TDEntity : DictionaryEntity
    {
        private readonly IDictionaryRepository<TDEntity> _dictionaryRepository; 

        public DictionaryBll(DictionaryRepository<TDEntity> repository) : base(repository)
        {
            _dictionaryRepository = repository;
        }

        public TDEntity GetByCode(int code)
        {
            return _dictionaryRepository.GetByCode(code);
        }
    }
}
