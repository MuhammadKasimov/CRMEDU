using AutoMapper;
using CRMEDU.Domain.Commons;
using CRMEDU.Domain.Entities.Admins;
using CRMEDU.Domain.Entities.Courses;
using CRMEDU.Domain.Entities.Lessons;
using CRMEDU.Domain.Entities.ManyRelations;
using CRMEDU.Service.DTOs.AdminsDTOs;
using CRMEDU.Service.DTOs.CommonDTOs;
using CRMEDU.Service.DTOs.CoursesDTOs;
using CRMEDU.Service.DTOs.LessonsDTOs;
using CRMEDU.Service.DTOs.ManyRelationsDTOs;

namespace CRMEDU.Service.Maper
{
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            CreateMap<Basics, BasicsForCreationDTO>().ReverseMap();
            CreateMap<Comment, CommentForCreationDTO>().ReverseMap();
            CreateMap<Security, SecurityForCreationDTO>().ReverseMap();
            CreateMap<Connection, ConnectionForCreationDTO>().ReverseMap();
            CreateMap<Admin, AdminForCreationDTO>().ReverseMap();
            CreateMap<Course, CourseForCreationDTO>().ReverseMap();
            CreateMap<Class, ClassForCreationDTO>().ReverseMap();
            CreateMap<Lesson, LessonForCreationDTO>().ReverseMap();
            CreateMap<ClassReporter, ClassReporterForCreationDTO>().ReverseMap();
        }
    }
}