using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class GrandsForGroup : IdEntity
    {
        public virtual Grand Grand { get; set; }
        public virtual SecurityGroup SecurityGroup { get; set; }
    }
}
