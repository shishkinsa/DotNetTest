using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNEStudentScoreModels
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BornDate { get; set; }
        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual List<Mark> Marks { get; set; }
    }
}
