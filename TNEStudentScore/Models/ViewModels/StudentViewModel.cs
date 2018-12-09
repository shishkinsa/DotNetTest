using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNEStudentScore.Models.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BornDate { get; set; }
        public int GroupId { get; set; }
        
        public string GroupName { get; set; }
        public string UniversityName { get; set; }
        public double AvgScore { get; set; }
    }
}
