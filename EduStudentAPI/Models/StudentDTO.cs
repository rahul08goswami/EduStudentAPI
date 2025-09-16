using System.ComponentModel.DataAnnotations;

namespace EduStudentAPI.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        //[DateCheck]
        //public DateTime AdmissionDate { get; set; }
        public int Age { get; set; }
        //public DateTime DOB { get; set; }
        //public int? DepartmentId { get; set; }
    }
}
