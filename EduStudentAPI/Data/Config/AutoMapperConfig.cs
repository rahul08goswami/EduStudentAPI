using AutoMapper;
using EduStudentAPI.Models;

namespace EduStudentAPI.Data.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(n => n.Name, x=> x.MapFrom( dst => dst.StudentName))
                .ForMember(n => n.Email, x=> x.MapFrom( dst => dst.EmailAddress))
                .ForMember(n => n.Age, x=> x.MapFrom( dst => DateTime.Now.Year - dst.DOB.Year))
                .ReverseMap();
                //.ForMember(n => n.Email, dst => dst.MapFrom(dst => dst.EmailAddress))
                //.ForMember(n => n.StudentName, dst => dst.MapFrom(dst => dst.Name));
                
        }
    }
}
