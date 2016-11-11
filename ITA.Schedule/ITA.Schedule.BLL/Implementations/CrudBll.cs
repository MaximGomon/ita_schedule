using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity;

namespace ITA.Schedule.BLL.Implementations
{
    public class CrudBll<TRepository, TEntity> : ICrudBll<TEntity>
        where TEntity : IdEntity, IEntity
        where TRepository : class, ICrudRepository<TEntity>
    {

        protected TRepository Repository { get; private set; }

        protected CrudBll(TRepository repository)
        {
            Repository = repository;
        } 

        //get any entity from db by predicate
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.Get(predicate);
        }

        //get all entities from db by type
        public IQueryable<TEntity> GetAll()
        {
            return Repository.GetAllEntities();
        }
        //get an entity from db by id
        public TEntity GetById(Guid id)
        {
            return Repository.GetById(id);
        }
        //insert an entity to db
        public void Insert(TEntity entity)
        {
            Repository.Add(entity);
        }
        //insert entities array to db
        public void InsertRange(IEnumerable<TEntity> range)
        {
            Repository.Add(range);
        }

        public void Remove(TEntity entity)
        {
            Repository.Delete(entity);
        }

        //Todo do we need this method?
        public void SaveChanges()
        {
            Repository.SaveChanges();
        }
        //update if exist or create if not exist
        public void Update(TEntity entity)
        {
            Repository.Update(entity);
        }
    }
  
}