using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNEStudentScoreModels;

namespace TNEStudentScoreClient.Models
{
    public class StudentScoreContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjectds { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<University> Universities { get; set; }

        public StudentScoreContext(DbContextOptions<StudentScoreContext> options):base(options)
        {

        }
    }
}
