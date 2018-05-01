﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Schedule.IntIta.Domain.Models
{
    public class Event : DictionaryEntity
    {
        public EventType TypeOfEvent { get; set; }
        public int? SubjectId { get; set; }
        public int? InitiatorId { get; set; }
        public int? RoomId { get; set; }
        public int? GroupId { get; set; }
        public TimeSlot Date { get; set; }
        public string Comments { get; set; }
        public bool IsAllDay { get; set; }
        public int? RepeatType { get; set; }
    }
}