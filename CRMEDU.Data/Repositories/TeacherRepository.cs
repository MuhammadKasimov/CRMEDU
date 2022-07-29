using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.Teachers;

namespace CRMEDU.Data.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
    }
}