using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VetApp.Models
{
    public class PetType
    {
        public int ID { get; set; }
        public string Description { get; set; }

        [ForeignKey("AnimalType")]
        public int AnimalTypeId { get; set; }
        public virtual AnimalType AnimalType { get; set; }

        [ForeignKey("Cover")]
        public int? CoverId { get; set; }
        public virtual Cover Cover { get; set; }

        [ForeignKey("Breed")]
        public int? BreedId { get; set; }
        public virtual Breed Breed { get; set; }
    }
}