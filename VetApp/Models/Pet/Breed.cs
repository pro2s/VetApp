using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VetApp.Models
{
    public class Breed
    {
        public int ID { get; set; }

        [DisplayName("Breed name")]
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}