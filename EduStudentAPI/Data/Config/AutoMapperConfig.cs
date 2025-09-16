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
                .ReverseMap();
                //.ForMember(n => n.Email, dst => dst.MapFrom(dst => dst.EmailAddress))
                //.ForMember(n => n.StudentName, dst => dst.MapFrom(dst => dst.Name));
                
        }
    }
}
