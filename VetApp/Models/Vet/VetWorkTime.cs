using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetApp.Models
{
    public class VetWorkTime
    {
        public int ID { get; set; }
        public virtual Vet Vet { get; set; }
        public virtual WorkTime WorkTime { get; set; }
    }
}