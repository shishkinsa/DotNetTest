using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNEStudentScore.Models;
using TNEStudentScore.Models.ViewModels;
using TNEStudentScoreModels;
using Microsoft.EntityFrameworkCore;

namespace TNEStudentScore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentScoresController : ControllerBase
    {
        private readonly StudentScoreContext _context;
        private readonly IMapper _mapper;

        public StudentScoresController(StudentScoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //// GET api/StudentScores
        //[HttpGet]
        //public ActionResult<IEnumerable<StudentViewModel>> Get()
        //{
        //    IEnumerable<StudentViewModel> students = Mapper.Map<Student[], IEnumerable<StudentViewModel>>(_context.Students.ToArray());
        //    return students.ToList();
        //}
        // GET api/StudentScores/<int:year>
        [HttpGet]
        public ActionResult<IEnumerable<StudentViewModel>> Get(int year, double avg = 4.5)
        {
            var stud = _context.Students
                .Include(t=>t.Marks)
                .Select(t => t.Marks.Average(z => z.Score))
                .Where(t => t > avg);
            //var stud2 = _context.Students.Select(t => t.Marks.Average(z => z.Score)).Where(t => t > avg);
            ////var test = _context.Marks.Include(t => t.Student).Include(t => t.Student.Group).ThenInclude(t=>t.University).ToList();
            //var grpMarkByStudent = _context.Marks
            //    .Where(t => t.ExamDate.Year == year)
            //    .GroupBy(t => t.Student);
            //var qAvgStudent = grpMarkByStudent
            //    //.Include(t => t.Key)
            //    .Include(t => t.Key.Group)
            //        .ThenInclude(t => t.University)
            //    .Where(t => t.Average(s => s.Score) > avg)
            //    .ToList();
            //var sView = qAvgStudent
            //    .Select(t => new StudentViewModel()
            //    {
            //        Id = t.Key.Id,
            //        AvgScore = t.Average(s => s.Score),
            //        BornDate = t.Key.BornDate,
            //        GroupId = t.Key.GroupId,
            //        GroupName = t.Key.Group.Name,
            //        Name = t.Key.Name,
            //        UniversityName = t.Key.Group.University.Name
            //    });

            //var studList = sView.ToList();

            return null;
        }
    }
}