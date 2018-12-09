using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNEStudentScoreModels
{
    public class Mark
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Score { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}
