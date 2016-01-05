using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VetApp.Models
{
    public class Cover
    {
        public int ID { get; set; }

        [DisplayName("Cover name")]
        public string Name { get; set; }
    }
}