using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetApp.Models
{

    public class WorkTime
    {
        public int ID { get; set; }

        public DayOfWeek Day { get; set; }
        
        // time in minutes
        public int start { get; set; }
        public int end { get; set; }
    }
}