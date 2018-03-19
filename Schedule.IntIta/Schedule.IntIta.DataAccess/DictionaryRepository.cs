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
        public TEntity GetEntityById(int Id)
        {
            using (var context = new IntitaDbContext())
            {
               return context.Set<TEntity>().FirstOrDefault(x => x.Id == Id);
            }
        }
    }


}    
    
