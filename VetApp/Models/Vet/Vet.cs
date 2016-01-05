using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VetApp.Models
{
    public class Vet
    {
        [Key] 
        public int ID { get; set; }
        public string Description { get; set; }

        [ForeignKey("Person")]
        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey("VetType")]
        public int VetTypeId { get; set; }
        public virtual VetType VetType { get; set; }
    }
}