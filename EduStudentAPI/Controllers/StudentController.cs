using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class StudentController(CollegeDBContext dbContext, IMapper mapper, ILogger<StudentController> logger) : ControllerBase
    {
        private readonly CollegeDBContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<StudentController> _logger = logger;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            _logger.LogTrace("LogTrace.");
            _logger.LogDebug("LogDebug.");
            _logger.LogInformation("LogInformation.");
            _logger.LogWarning("LogWarning.");
            _logger.LogError("LogError.");
            _logger.LogCritical("LogCritical.");
            //var students = await _dbContext.Students
            //    .Select(s => new StudentDTO
            //    {
            //        Id = s.Id,
            //        StudentName = s.StudentName,
            //        Email = s.Email,
            //        Address = s.Address,
            //        DOB = s.DOB                    
            //    })
            //    .ToListAsync();

            //var students = await _dbContext.Students.ToListAsync();
            //var studentsDTO = (List<StudentDTO>) _mapper.Map(students, typeof(List<Student>), typeof(List<StudentDTO>));
            //var studentsDTO = _mapper.Map<List<StudentDTO>>(students);

            //•	ProjectTo<StudentDTO>(_mapper.ConfigurationProvider): AutoMapper's QueryableExtensions builds an expression
            //tree that maps Student → StudentDTO. That expression is translated by EF Core into SQL so only the DTO fields are selected.
            var studentsDTO = await _dbContext.Students
                .ProjectTo<StudentDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();


            return Ok(studentsDTO);
        }
    }
}
