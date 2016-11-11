using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ITA.Schedule.Entity;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Base interface to be implemented by CRUDRepository class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ICRUDRepository<TEntity> where TEntity : IEntity
    {
        // add an entity to DB
        void Add(TEntity entity);
        // add range of entities to DB
        void Add(IEnumerable<TEntity> range);
        // get an entity from DB using ID
        TEntity GetById(Guid id);
        // delete entity from DB by Id
        void Delete(Guid id);
        // delete particular entity
        void Delete(TEntity entity);
        // de;ete entities by predicate
        void Delete(Expression<Func<TEntity, bool>> predicate);
        // update an entity in DB
        void Update(TEntity entity);
        // get all entities from DB
        IQueryable<TEntity> GetAllEntities();
        // save changes once operation has been completed
        void SaveChanges();
    }
}