using System;
using System.ComponentModel.DataAnnotations;

namespace CRMEDU.Domain.Commons
{
    public class Comment : IAuditable
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long BasicsId { get; set; }

        [MaxLength(500)]
        public string Context { get; set; }
    }
}
