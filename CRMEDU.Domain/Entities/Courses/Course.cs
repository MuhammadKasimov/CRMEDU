using CRMEDU.Domain.Commons;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRMEDU.Domain.Entities.Courses
{
    public class Course : Auditable
    {
        [MaxLength(65)]
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
