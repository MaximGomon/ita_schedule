using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity;

namespace ITA.Schedule.BLL.Implementations.Base
{
    public class DictionaryBl<TDEntity> : CrudBll<DictionaryRepository<TDEntity>, TDEntity>,
        IDictionaryRepository<TDEntity> where TDEntity : DictionaryEntity
    {
        private readonly IDictionaryRepository<TDEntity> _dictionaryRepository; 

        public DictionaryBl(DictionaryRepository<TDEntity> repository) : base(repository)
        {
            _dictionaryRepository = repository;
        }

        public TDEntity GetByCode(int code)
        {
            return _dictionaryRepository.GetByCode(code);
        }
    }
}
