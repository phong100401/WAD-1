using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practice_WAD.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Exam_WAD")
        {
        }

        public System.Data.Entity.DbSet<Practice_WAD.Models.Classroom> Classrooms { get; set; }

        public System.Data.Entity.DbSet<Practice_WAD.Models.ExamSubject> ExamSubjects { get; set; }

        public System.Data.Entity.DbSet<Practice_WAD.Models.Test> Tests { get; set; }

        public System.Data.Entity.DbSet<Practice_WAD.Models.Falculty> Falculties { get; set; }
    }
}