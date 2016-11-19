using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITA.Schedule.Models
{
    public class SchedulerViewModel
    {
        public List<string> ColumnHeaders { get; set; }
        public List<string> RowHeaders { get; set; }
        public List<Element> Events { get; set; }
        
    }
}