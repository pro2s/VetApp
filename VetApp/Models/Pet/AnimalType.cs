using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VetApp.Models
{
    public class AnimalType
    {
        public int ID { get; set; }

        [DisplayName("Animal type")]
        public string Name { get; set; }
    }
}