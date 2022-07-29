using CRMEDU.Service.DTOs.CoursesDTOs;

namespace CRMEDU.Service.DTOs.LessonsDTOs
{
    public class LessonForCreationDTO
    {
        public ClassForCreationDTO Class { get; set; }
        public string Title { get; set; }
    }
}
