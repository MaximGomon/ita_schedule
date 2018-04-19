using Schedule.IntIta.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Schedule.IntIta.DataAccess.Context;

namespace Schedule.IntIta.DataAccess
{
    public class DictionaryRepository<TEntity> where TEntity : DictionaryEntity
    {
        private readonly IntitaDbContext _context;

        public DictionaryRepository(IntitaDbContext context)
        {
            _context = context;
        }

        public TEntity GetEntityById(int Id)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id == Id);
        }
    }


}

