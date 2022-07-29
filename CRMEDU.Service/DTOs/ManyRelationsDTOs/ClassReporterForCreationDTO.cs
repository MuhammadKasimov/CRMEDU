using CRMEDU.Service.DTOs.CoursesDTOs;
using CRMEDU.Service.DTOs.ReportersDTOs;

namespace CRMEDU.Service.DTOs.ManyRelationsDTOs
{
    public class ClassReporterForCreationDTO
    {
        public ClassForCreationDTO Class { get; set; }
        public ReporterForCreationDTO Reporters { get; set; }
    }
}
