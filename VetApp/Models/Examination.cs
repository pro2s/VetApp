using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VetApp.Models
{
    public class Examination
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Pet")]
        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public float? Temperature { get; set; }
        public float? Pulse { get; set; }
        public float? Weight { get; set; }
        public float? Lenght { get; set; }
        public float? Hieght { get; set; }
        public string CoverState { get; set; }

        [Required]
        public bool AtClinic { get; set; }
    }
}