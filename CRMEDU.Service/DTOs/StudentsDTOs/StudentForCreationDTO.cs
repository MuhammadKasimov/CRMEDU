using CRMEDU.Service.DTOs.CommonDTOs;
using CRMEDU.Service.DTOs.CoursesDTOs;

namespace CRMEDU.Service.DTOs.StudentsDTOs
{
    public class StudentForCreationDTO
    {

        public CommentForCreationDTO SentComments { get; set; }

        public BasicsForCreationDTO Basics { get; set; }

        public ClassForCreationDTO Class { get; set; }

        public ConnectionForCreationDTO Connection { get; set; }
    }
}
