using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class SecurityGroup : DictionaryEntity
    {
        public SecurityGroup()
        {
            Grands = new List<Grand>();   
        }

        public virtual ICollection<Grand> Grands { get; set; } 
    }
}
