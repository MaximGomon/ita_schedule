﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ITA.Schedule.Entity;

namespace ITA.Schedule.BLL.Interface.Base
{
    public interface ICrudBl<TEntity>
        where TEntity : IdEntity, IEntity
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Remove(Guid id);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entity);
        void SaveChanges();

    }
}