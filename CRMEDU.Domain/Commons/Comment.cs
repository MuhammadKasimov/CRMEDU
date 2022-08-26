using System.ComponentModel.DataAnnotations;

namespace CRMEDU.Domain.Commons
{
    public class Comment : Auditable
    {
        public long? BasicsId { get; set; }

        [MaxLength(500)]
        public string Context { get; set; }
    }
}
