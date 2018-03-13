using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Schedule.IntIta.Domain.Models
{
    /// <summary>Represents the time slot betwen start and end event.</summary>
    public class TimeSlot : DeletableEntity
    {
        /// <summary>Start time in full format with date and time. Must be datetime2 in MsSQL, or DATETIME in MsSql</summary>
        [DisplayName("Дата начала")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        /// <summary>End time in full format with date and time. Must be datetime2 in MsSQL, or DATETIME in MsSql</summary>
        [DisplayName("Дана окончания")]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
        
        /// <summary>Represent the Id of time slots type.</summary>
        public int IdType { get; set; }
    }
}