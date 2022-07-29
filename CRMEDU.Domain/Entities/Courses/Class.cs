using CRMEDU.Domain.Commons;
using CRMEDU.Domain.Entities.Students;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMEDU.Domain.Entities.Courses
{
    public class Class : Auditable
    {

        public long CourseId { get; set; }
        public Course Course { get; set; }

        public long StudentsId { get; set; }
        public ICollection<Student> Students { get; set; }

        [MaxLength(65)]
        public string ClassName { get; set; }
        public bool IsActive { get; set; }

    }
}
