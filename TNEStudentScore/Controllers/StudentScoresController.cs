using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNEStudentScore.Models;
using TNEStudentScoreModels;
using Microsoft.EntityFrameworkCore;
using TNEStudentScoreModels.ViewModels;

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
       
        // GET api/StudentScores
        [HttpGet]
        public ActionResult<IEnumerable<StudentViewModel>> Get(int year, double avg = 4.5)
        {
            if (year == 0)
            {
                return BadRequest();
            }
            var studentMarks = _context.Marks
                .Include(t=>t.Student)
                    .ThenInclude(t=>t.Group)
                        .ThenInclude(t=>t.University)
                .Where(t => t.ExamDate.Year == year)
                .ToList();
            var avgStudents = studentMarks
                .GroupBy(t => t.Student)
                .Where(t => t.Average(z => z.Score) > avg)
                .Select(t => new StudentViewModel()
                {
                    Id = t.Key.Id,
                    AvgScore = t.Average(z=>z.Score),
                    BornDate = t.Key.BornDate,
                    GroupId = t.Key.GroupId,
                    GroupName = t.Key.Group.Name,
                    Name = t.Key.Name,
                    UniversityName = t.Key.Group.University.Name
                });

            var studList = avgStudents.ToList();

            return studList;
        }
    }
}