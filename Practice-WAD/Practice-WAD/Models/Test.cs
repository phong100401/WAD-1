using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice_WAD.Models
{
    public class Test
    {
        public int ID { get; set; }
        public string Starttime { get; set; }
        public string ExamDate { get; set; }
        public string ExamDur { get; set; }
        public int ClassroomID { get; set; }
        public int ExamSubjectID { get; set; }
        public int FalcultyID { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual ExamSubject ExamSubject { get; set; }
        public virtual Falculty Falculty { get; set; }
    }
}