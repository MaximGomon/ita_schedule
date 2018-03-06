﻿using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Domain.Models.Enumerations;

namespace Schedule.IntIta.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public int SeatNumber { get; set; }
        public string Name { get; set; }
        public RoomStatus RoomStatus { get; set; }
    }
}