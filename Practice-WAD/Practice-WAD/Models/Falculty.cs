using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice_WAD.Models
{
    public class Falculty
    {
        [Key]
        public int FalcultyID { get; set; }
        [Required(ErrorMessage = "Please enter the right Falculty")]
        public string Name { get; set; }
    }
}