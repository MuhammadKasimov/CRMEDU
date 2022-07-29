using CRMEDU.Domain.Enums;

namespace CRMEDU.Service.DTOs.CommonDTOs
{
    public class CommentForCreationDTO
    {
        public string Context { get; set; }
        public SentTo SentTo { get; set; }
    }
}
