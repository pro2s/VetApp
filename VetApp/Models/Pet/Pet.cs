using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace VetApp.Models
{
	public enum Sex { Male, Famale}
    public enum Size { Micro, Mini, Small, Normal, Large, ExtraLarge}	
    public class Pet
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string NickName { get; set; }
        public string ChipID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BornDate { get; set; }

        public Sex Sex { get; set; }
        public Size Size { get; set; }
        
        [ForeignKey("PetType")]
        public int PetTypeId { get; set; }
        public virtual PetType PetType { get; set; }
        public string CoverColor { get; set; }

        [ForeignKey("Owner")]
        public int PersonId { get; set; }
        public virtual Person Owner { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Examination> Examinations { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }


}