﻿using System;
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
        // declare protected context to be accessible in the derived repositories
        protected ScheduleDbContext ContextDb { get; } = new ScheduleDbContext();

        // addan entity to the DB
        public virtual void Add(TEntity entity)
        {
            ContextDb.Set<TEntity>().Add(entity);
            SaveChanges();
        }

        // add range of entities to the DB
        public virtual void Add(IEnumerable<TEntity> entities)
        {
            ContextDb.Set<TEntity>().AddRange(entities);
            SaveChanges();
        }

        // get a entity from the DB by Id
        public virtual TEntity GetById(Guid id)
        {
            return ContextDb.Set<TEntity>().Find(id);
        }

        // delete an entity by ID
        public virtual void Delete(Guid id)
        {
            Delete(GetById(id));
            SaveChanges();
        }

        // delete an entity itself
        public virtual void Delete(TEntity entity)
        {
            ContextDb.Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        // update an entity
        public virtual void Update(TEntity entity)
        {
            ContextDb.Set<TEntity>().AddOrUpdate<TEntity>(entity);
            SaveChanges();
        }

        // get all entities from the DB
        public virtual IQueryable<TEntity> GetAllEntities()
        {
            return ContextDb.Set<TEntity>();
        }

        // save changes after performing an operation
        public virtual void SaveChanges()
        {
            ContextDb.SaveChanges();
        }
    }
}