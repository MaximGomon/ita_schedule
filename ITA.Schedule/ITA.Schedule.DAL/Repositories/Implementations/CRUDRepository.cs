using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// Base repository to perform CRUD operations over DB entities
    /// </summary>
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : IdEntity, IEntity
    {
        /// <summary>declare protected context to be accessible in the derived repositories
        protected ScheduleDbContext ContextDb { get; } = new ScheduleDbContext();

        /// <summary>add an entity to the DB</summary>
        public virtual void Add(TEntity entity)
        {
            ContextDb.Set<TEntity>().Add(entity);
            SaveChanges();
        }

        /// <summary>add range of entities to the DB</summary>
        public virtual void Add(IEnumerable<TEntity> entities)
        {
            ContextDb.Set<TEntity>().AddRange(entities);
            SaveChanges();
        }

        /// <summary>get a entity from the DB by Id</summary>
        public virtual TEntity GetById(Guid id)
        {
            return ContextDb.Set<TEntity>().Find(id);
        }

        /// <summary>get by predicate</summary>
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return ContextDb.Set<TEntity>().Where(predicate);
        }

        /// <summary>delete an entity by ID</summary>
        public virtual void Delete(Guid id)
        {
            Delete(GetById(id));
        }

        /// <summary>delete an entity itself</summary>
        public virtual void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        /// <summary> activate inactive entity</summary>
        public void Activate(Guid id)
        {
            Activate(GetById(id));
        }

        /// <summary>activate an entity itself</summary>
        public void Activate(TEntity entity)
        {
            entity.IsDeleted = false;
            Update(entity);
        }

        /// <summary>update an entity</summary>
        public virtual void Update(TEntity entity)
        {
            ContextDb.Set<TEntity>().AddOrUpdate<TEntity>(entity);
            SaveChanges();
        }

        /// <summary>get all entities from the DB</summary>
        public virtual IQueryable<TEntity> GetAllEntities()
        {
            return ContextDb.Set<TEntity>();
        }

        /// <summary>save changes after performing an operation</summary>
        public virtual void SaveChanges()
        {
            ContextDb.SaveChanges();
        }
    }
}