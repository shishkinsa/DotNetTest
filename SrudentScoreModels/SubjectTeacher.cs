using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNEStudentScoreModels
{
    public class SubjectTeacher
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
