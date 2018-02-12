using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Domain.Models
{
    interface ICrud
    {
        void Add();
        void Read();
        void Update();
        void Delete();
    }
}
