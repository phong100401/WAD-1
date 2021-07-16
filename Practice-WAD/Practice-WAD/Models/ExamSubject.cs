using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practice_WAD.Models
{
    public class ExamSubject
    {
        [Key]
        public int ExamSubjectID { get; set; }
        [Required(ErrorMessage = "Please enter the right Exam Subject")]
        public string Name { get; set; }
    }
}