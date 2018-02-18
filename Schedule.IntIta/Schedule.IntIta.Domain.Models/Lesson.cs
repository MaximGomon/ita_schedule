using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Domain.Models
{
    public class Lesson : IdEntity
    {
       public int SubjectId { get; set; }
       public int TeacherId { get; set; }
       public int  RoomId { get; set; }
       public int GroupId { get; set; }
       public DateTime Date { get; set; }
    }
}
