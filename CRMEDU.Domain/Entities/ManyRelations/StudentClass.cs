using CRMEDU.Domain.Entities.Courses;
using CRMEDU.Domain.Entities.Students;

namespace CRMEDU.Domain.Entities.ManyRelations
{
    public class StudentClass
    {
        public long Id { get; set; }

        public long StudentId { get; set; }
        public Student Student { get; set; }

        public long ClassId { get; set; }
        public Class Class { get; set; }
    }
}
