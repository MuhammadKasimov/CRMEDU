using CRMEDU.Service.DTOs.CommonDTOs;

namespace CRMEDU.Service.DTOs.AdminsDTOs
{
    public class AdminForCreationDTO
    {
        public BasicsForCreationDTO Basics { get; set; }
        public ConnectionForCreationDTO Connection { get; set; }
    }
}

