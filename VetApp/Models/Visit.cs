using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VetApp.Models
{
    public enum Status {
        Requested,
        Scheduled,
        Canceled,
        Finished
    }

    public class Visit
    {
        [Key]
        public int ID { get; set; }
        public DateTime VisitDate { get; set; }

        public Status Status { get; set; }
        
        [ForeignKey("VisitType")]
        public int VisitTypeId { get; set; }
        public virtual VisitType VisitType { get; set; }

        [ForeignKey("Pet")]
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }


        [ForeignKey("Vet")]
        public int VetId { get; set; }
        public virtual Vet Vet { get; set; }

        [ForeignKey("Examination")]
        public int? ExaminationId { get; set; }
        public virtual Examination Examination { get; set; }

        public Visit()
        {
            Status = Status.Requested;
        }
    }
}