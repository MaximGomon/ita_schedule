using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class Grand : DictionaryEntity
    {
        public Grand()
        {
            SecurityGroups = new List<SecurityGroup>();
        }

        public virtual ICollection<SecurityGroup> SecurityGroups { get; set; } 
    }
}
