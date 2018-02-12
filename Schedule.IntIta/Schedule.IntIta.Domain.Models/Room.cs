﻿using Schedule.IntIta.Domain.Models.Enumerations;

namespace Schedule.IntIta.Domain.Models
{
    public class Room : DeletableEntity
    {
        public int SeatNumber { get; set; }
        public string Name { get; set; }
        public RoomStatus RoomStatus { get; set; }
    }
}
