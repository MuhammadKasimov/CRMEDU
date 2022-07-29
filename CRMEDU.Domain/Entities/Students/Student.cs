using CRMEDU.Domain.Commons;
using CRMEDU.Domain.Entities.Courses;

namespace CRMEDU.Domain.Entities.Students
{
    public class Student : Auditable
    {

        public long SentCommentsId { get; set; }
        public Comment SentComments { get; set; }

        public long BasicsId { get; set; }
        public Basics Basics { get; set; }

        public long ClassId { get; set; }
        public Class Class { get; set; }

        public long ConnectionId { get; set; }
        public Connection Connection { get; set; }

    }
}