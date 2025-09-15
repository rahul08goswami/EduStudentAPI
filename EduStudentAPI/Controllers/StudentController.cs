using EduStudentAPI.Data;
using EduStudentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduStudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CollegeDBContext _dbContext;
        //private readonly IMapper mapper;

        public StudentController(CollegeDBContext dbContext)
        {
            _dbContext = dbContext;
            //this.mapper = mapper;
        }
        //public StudentController(CollegeDBContext dbContext, IMapper mapper)
        //{
        //    _dbContext = dbContext;
        //    //this.mapper = mapper;
        //}

        [HttpGet]
        public async Task<List<StudentDTO>> GetStudents()
        //public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            //var students = await _dbContext.Students.ToListAsync();
            var students = await _dbContext.Students
                .Select(s => new StudentDTO
                {
                    Id = s.Id,
                    StudentName = s.StudentName,
                    Email = s.Email,
                    Address = s.Address,
                    DOB = s.DOB,
                    DepartmentId = s.DepartmentId
                })
                .ToListAsync();

            return students;
        }
    }
}
