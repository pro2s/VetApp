using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetApp.Models
{

    public class WorkTime
    {
        public int ID { get; set; }

        // time in minutes

        [UIHint("WorkTimePart")]
        public int start { get; set; }
        [UIHint("WorkTimePart")]
        public int end { get; set; }
    }
}