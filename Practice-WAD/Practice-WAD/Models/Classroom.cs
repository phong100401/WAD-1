using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice_WAD.Models
{
    public class Classroom
    {
        [Key]
        public int ClassroomID { get; set; }
        [Required(ErrorMessage = "Please enter the correct Classroom")]
        public string Name { get; set; }
    }
}