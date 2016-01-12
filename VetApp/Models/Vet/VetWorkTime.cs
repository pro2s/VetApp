using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VetApp.Models
{
    public class VetWorkTime
    {
        public int ID { get; set; }
        public DayOfWeek Day { get; set; }

        [ForeignKey("Vet")]
        public int VetId { get; set; }
        public virtual Vet Vet { get; set; }

        [ForeignKey("WorkTime")]
        public int WorkTimeId { get; set; }
        public virtual WorkTime WorkTime { get; set; }
    }
}