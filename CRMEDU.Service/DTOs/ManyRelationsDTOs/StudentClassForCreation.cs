using CRMEDU.Service.DTOs.CoursesDTOs;
using CRMEDU.Service.DTOs.StudentsDTOs;

namespace CRMEDU.Service.DTOs.ManyRelationsDTOs
{
    public class StudentClassForCreationDTO
    {

        public StudentForCreationDTO Student { get; set; }

        public ClassForCreationDTO Class { get; set; }
    }
}
