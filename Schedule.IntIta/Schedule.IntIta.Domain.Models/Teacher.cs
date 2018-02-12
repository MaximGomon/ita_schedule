using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Domain.Models
{
    class Teacher
    {
        public string FirstName
        {
            get => FirstName;
            set
            {
                if (value.Length > 0) FirstName = value;
            }
        }
        public string LastName
        {
            get => LastName;
            set
            {
                if (value.Length > 0) LastName = value;
            }
        }
        public string Email
        {
            get => Email;
            set
            {
                if (value.Length > 0) Email = value;
            }
        }
        public Subject[] Subjects;
        public TimeSlot[] TimeSlots;
    }
}
