using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VetApp.Models
{
    public class VetType
    {   
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public bool IsDoctor { get; set; }

    }
}