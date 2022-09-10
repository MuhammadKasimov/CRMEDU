using CRMEDU.Domain.Commons;
using CRMEDU.Domain.Entities.Admins;
using CRMEDU.Domain.Entities.Courses;
using CRMEDU.Domain.Entities.Lessons;
using CRMEDU.Domain.Entities.ManyRelations;
using CRMEDU.Domain.Entities.Reporters;
using CRMEDU.Domain.Entities.Students;
using CRMEDU.Domain.Entities.Teachers;
using System;
using System.Threading.Tasks;

namespace CRMEDU.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Admin> AdminRepository { get; }
        IGenericRepository<Class> ClassRepository { get; }
        IGenericRepository<ClassReporter> ClassReporterRepository { get; }
        IGenericRepository<Comment> CommentRepository { get; }
        IGenericRepository<Course> CourseRepository { get; }
        IGenericRepository<Lesson> LessonRepository { get; }
        IGenericRepository<Reporter> ReporterRepository { get; }
        IGenericRepository<StudentClass> StudentClassRepository { get; }
        IGenericRepository<Student> StudentRepository { get; }
        IGenericRepository<Teacher> TeacherRepository { get; }
        Task SaveAsync();
    }
}
