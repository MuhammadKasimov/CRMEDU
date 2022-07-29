using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.Courses;

namespace CRMEDU.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
    }
}
