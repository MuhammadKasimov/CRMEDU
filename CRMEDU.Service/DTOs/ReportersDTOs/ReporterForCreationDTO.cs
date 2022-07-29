using CRMEDU.Domain.Enums;
using CRMEDU.Service.DTOs.StudentsDTOs;

namespace CRMEDU.Service.DTOs.ReportersDTOs
{
    public class ReporterForCreationDTO
    {
        public StudentForCreationDTO Student { get; set; }
        public Muster Muster { get; set; }
    }
}
