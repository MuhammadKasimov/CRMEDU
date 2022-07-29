using CRMEDU.Service.DTOs.StudentsDTOs;
using CRMEDU.Service.DTOs.TeachersDTOs;
using System.Collections.Generic;

namespace CRMEDU.Service.DTOs.CoursesDTOs
{
    public class ClassForCreationDTO
    {
        public CourseForCreationDTO Course { get; set; }

        public TeacherForCreationDTO Teacher { get; set; }

        public ICollection<StudentForCreationDTO> Students { get; set; }

        public string ClassName { get; set; }
        public bool IsActive { get; set; }
    }
}