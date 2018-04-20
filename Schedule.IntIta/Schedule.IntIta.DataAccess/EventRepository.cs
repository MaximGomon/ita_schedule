﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public class EventRepository : IEventRepository
    {
        private readonly IntitaDbContext _context;

        public EventRepository(IntitaDbContext context)
        {
            _context = context;
        }

        public void Insert(Event item)
        {
            //using (var context = new IntitaDbContext())
            //{
                Event newEvent = new Event()
                {
                    Comments = item.Comments,
                    GroupId = item.GroupId,
                    InitiatorId = item.InitiatorId,
                    IsDeleted = item.IsDeleted,
                    RoomId = item.RoomId,
                    SubjectId = item.SubjectId,
                    Date = item.Date,
                };

                _context.Events.Add(newEvent);
                newEvent.TypeOfEvent = _context.EventTypes.First(x => x.Id == item.TypeOfEvent.Id);
                _context.SaveChanges();
            //}
        }

        public Event Get(int id)
        {
            //using (var context = new IntitaDbContext())
            //{
                return _context.Events
                    .Include(p => p.TypeOfEvent)
                    .Include(p => p.Date)
                    .Single(x => x.Id == id);
            //}
        }

        public void Update(Event modifiedItem)
        {
            //using (var context = new IntitaDbContext())
            //{
                modifiedItem.TypeOfEvent = _context.EventTypes.Single(x => x.Id == modifiedItem.TypeOfEvent.Id);
            _context.Events.Update(modifiedItem);
            _context.SaveChanges();
            //}
        }

        public void Delete(int id)
        {
            //using (var context = new IntitaDbContext())
            //{
                var item = _context.Events.First(x => x.Id == id);
                item.IsDeleted = true;
            _context.SaveChanges();
            //}
        }

        public IEnumerable<Event> GetAll()
        {
            //using (var context = new IntitaDbContext())
            //{
                var result = _context.Events
                    .Include(p => p.TypeOfEvent)
                    .Include(p => p.Date);
                return result.ToList();
            //}
        }

        public IEnumerable<Event> GetActive()
        {
            //using (var context = new IntitaDbContext())
            //{
                var result = _context.Events.Where(x => x.IsDeleted == false)
                    .Include(p => p.TypeOfEvent)
                    .Include(p => p.Date);
                return result.ToList();
            //}
        }
    }
}
