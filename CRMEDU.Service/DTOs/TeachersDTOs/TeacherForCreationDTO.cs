using CRMEDU.Service.DTOs.CommonDTOs;
using CRMEDU.Service.DTOs.CoursesDTOs;

namespace CRMEDU.Service.DTOs.TeachersDTOs
{
    public class TeacherForCreationDTO
    {
        public BasicsForCreationDTO Basics { get; set; }

        public ClassForCreationDTO Class { get; set; }
        public decimal Salary { get; set; }
        public ConnectionForCreationDTO Connection { get; set; }
        public CourseForCreationDTO Course { get; set; }
        public CommentForCreationDTO SentComments { get; set; }

    }
}