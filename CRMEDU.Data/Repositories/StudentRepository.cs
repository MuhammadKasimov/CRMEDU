using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.Students;

namespace CRMEDU.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
    }
}
