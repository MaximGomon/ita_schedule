﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ITA.Schedule.Entity;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Base interface to be implemented by CrudRepository class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ICrudRepository<TEntity> where TEntity : IdEntity, IEntity
    {
        /// <summary>add an entity to DB </summary>
        void Add(TEntity entity);
        /// <summary>add range of entities to DB</summary>
        void Add(IEnumerable<TEntity> range);
        /// <summary>get an entity from DB using ID</summary>
        TEntity GetById(Guid id);
        /// <summary>get an entity from DB using predicate</summary>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        /// <summary>delete entity from DB by Id</summary>
        void Delete(Guid id);
        /// <summary>delete particular entity</summary>
        void Delete(TEntity entity);
        /// <summary>activate entity from DB by Id</summary>
        void Activate(Guid id);
        /// <summary>activate particular entity</summary>
        void Activate(TEntity entity);
        /// <summary>update an entity in DB</summary>
        void Update(TEntity entity);
        /// <summary>get all entities from DB</summary>
        IQueryable<TEntity> GetAllEntities();
        /// <summary>save changes once operation has been completed</summary>
        void SaveChanges();
    }
}