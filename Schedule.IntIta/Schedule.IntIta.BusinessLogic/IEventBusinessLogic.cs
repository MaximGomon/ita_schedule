﻿using Schedule.IntIta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Schedule.IntIta.Integration;

namespace Schedule.IntIta.BusinessLogic
{
    public interface IEventBusinessLogic
    {
        void Add(Event item);
        Event Read(int id);
        void Update(Event modifiedItem);
        void Delete(int id);
        IEnumerable<Event> GetAll();
        IEnumerable<Room> GetAllRooms();
        IEnumerable<Group> GetAllGroups();
        List<User> FindUsers(string searchStr);
        User GetUsersById(int? id);
        Group GetGroupById(int id);
        IEnumerable<Event> GetActive();
        Room GetRoomById(int id);
        List<User> FindLocalUsers(string searchStr);
        IEnumerable<EventType> GetEventTypes();
        IEnumerable<TimeSlotTypes> GetTimeSlotTypes();
        IEnumerable<Room> GetRooms();
        IEnumerable<Subject> GetSubjects();
        IEnumerable<RepeatTypes> GetRepeatTypes();
    }
}
