using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TNEStudentScoreModels;

namespace TNEStudentScore.Models
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed database
            // Seed Teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Name = "Петров Аввакум Авдеевич" },   // История
                new Teacher { Id = 2, Name = "Новиков Альберт Оскарович" }, // Математика
                new Teacher { Id = 3, Name = "Богданов Георгий Наумович" }  // ФП
            );
            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Тукаев Алексей Ерофеевич", BornDate = new DateTime(1989, 01, 25), GroupId = 1 },
                new Student { Id = 2, Name = "Шихина Вероника Данилевна", BornDate = new DateTime(1985, 11, 14), GroupId = 2 },
                new Student { Id = 3, Name = "Закруткин Лаврентий Филиппович", BornDate = new DateTime(1988, 06, 05), GroupId = 3 },
                new Student { Id = 4, Name = "Ермолин Тихон Филимонович", BornDate = new DateTime(1988, 06, 05), GroupId = 1 },
                new Student { Id = 5, Name = "Хмельнова Эвелина Ираклиевна", BornDate = new DateTime(1987, 03, 07), GroupId = 2 },
                new Student { Id = 6, Name = "Закруткин Лаврентий Филиппович", BornDate = new DateTime(1986, 02, 09), GroupId = 3 }
            );
            // Seed Subjects
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "История"},
                new Subject { Id = 2, Name = "Дискретная математика" },
                new Subject { Id = 3, Name = "Фунциональное программирование" }
            );
            // Seed University
            modelBuilder.Entity<University>().HasData(
                new University { Id = 1, Name = "Институт 1" },
                new University { Id = 2, Name = "Институт 2" }
            );
            // Seed Groups
            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "Группа программистов И1", UniversityId = 1 },
                new Group { Id = 2, Name = "Группа историков И1", UniversityId = 2 },
                new Group { Id = 3, Name = "Группа программистов И2", UniversityId = 1 }
            );
            // Seed Subject teachers
            modelBuilder.Entity<SubjectTeacher>().HasData(
                new SubjectTeacher { Id = 1, SubjectId = 1, TeacherId = 1 },
                new SubjectTeacher { Id = 2, SubjectId = 2, TeacherId = 2 },
                new SubjectTeacher { Id = 3, SubjectId = 3, TeacherId = 3 }
            );
            // Seed Student score
            modelBuilder.Entity<Mark>().HasData(
                new Mark { Id = 1, SubjectId = 1, StudentId = 1, Score = 3, ExamDate = new DateTime(2018, 01, 24) },
                new Mark { Id = 2, SubjectId = 2, StudentId = 1, Score = 4, ExamDate = new DateTime(2018, 02, 24) },
                new Mark { Id = 3, SubjectId = 3, StudentId = 1, Score = 5, ExamDate = new DateTime(2018, 03, 24) },
                new Mark { Id = 4, SubjectId = 1, StudentId = 2, Score = 4, ExamDate = new DateTime(2017, 04, 24) },
                new Mark { Id = 5, SubjectId = 2, StudentId = 2, Score = 3, ExamDate = new DateTime(2016, 05, 24) },
                new Mark { Id = 6, SubjectId = 3, StudentId = 2, Score = 2, ExamDate = new DateTime(2017, 04, 24) },
                new Mark { Id = 7, SubjectId = 1, StudentId = 3, Score = 4, ExamDate = new DateTime(2016, 03, 24) },
                new Mark { Id = 8, SubjectId = 2, StudentId = 3, Score = 5, ExamDate = new DateTime(2016, 02, 24) },
                new Mark { Id = 9, SubjectId = 3, StudentId = 4, Score = 5, ExamDate = new DateTime(2018, 01, 24) }
            );
            #endregion
        }
    }
}
