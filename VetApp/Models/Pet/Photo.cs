using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VetApp.Models
{
    public class Photo
    {
        public int ID { get; set; }
        public string Path { get; set; }
        public bool Profile { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Pet")]
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
    }
}