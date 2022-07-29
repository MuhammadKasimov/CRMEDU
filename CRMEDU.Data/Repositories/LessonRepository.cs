using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.Lessons;

namespace CRMEDU.Data.Repositories
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
    }
}
