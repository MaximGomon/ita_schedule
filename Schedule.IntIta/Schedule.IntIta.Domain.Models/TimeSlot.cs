using System;

namespace Schedule.IntIta.Domain.Models
{
    /// <summary>Represents the time slot betwen start and end event.</summary>
    public class TimeSlot : DeletableEntity
    {
        /// <summary>Start time in full format with date and time. Must be datetime2 in MsSQL, or DATETIME in MsSql</summary>
        public DateTime StartTime { get; set; }
        
        /// <summary>End time in full format with date and time. Must be datetime2 in MsSQL, or DATETIME in MsSql</summary>
        public DateTime EndTime { get; set; }
        
        /// <summary>Represent the Id of time slots type.</summary>
        public int IdType { get; set; }
    }
}