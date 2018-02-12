using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Domain.Models
{
    public class Room : DeletableEntity,ICrud
    {
        public int SeatNumber { get; set; }
        public string Name { get; set; }
        public enum Status
        {
            IsActive,
            IsReserved,
            IsUnavaliable
        };
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

               

        
    }
    

}
