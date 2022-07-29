using CRMEDU.Domain.Commons;
using CRMEDU.Domain.Entities.Courses;
using System.ComponentModel.DataAnnotations;

namespace CRMEDU.Domain.Entities.Lessons
{
    public class Lesson : Auditable
    {
        public long ClassId { get; set; }
        public Class Class { get; set; }

        [MaxLength(80)]
        public string Title { get; set; }
        public long RepoterId { get; set; }
    }
}