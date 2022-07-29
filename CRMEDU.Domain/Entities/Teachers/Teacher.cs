using CRMEDU.Domain.Commons;
using CRMEDU.Domain.Entities.Courses;

namespace CRMEDU.Domain.Entities.Teachers
{
    public class Teacher : Auditable
    {
        public long BasicsId { get; set; }
        public Basics Basics { get; set; }

        public long ClassId { get; set; }
        public Class Class { get; set; }

        public decimal Salary { get; set; }

        public long ConnectionId { get; set; }
        public Connection Connection { get; set; }

        public long CourseId { get; set; }
        public Course Course { get; set; }

        public long SentCommentsId { get; set; }
        public Comment SentComments { get; set; }
    }
}