using System.ComponentModel.DataAnnotations.Schema;

namespace EduStudentAPI.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        [Column(name: "Email")]
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
    }
}
