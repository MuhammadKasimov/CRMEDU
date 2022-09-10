using CRMEDU.Data.Context;
using CRMEDU.Data.IRepositories;
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

namespace CRMEDU.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CRMEDUDBContext dbContext;

        public UnitOfWork(CRMEDUDBContext dbContext)
        {
            this.dbContext = dbContext;
            AdminRepository = new GenericRepository<Admin>(dbContext);
            ClassReporterRepository = new GenericRepository<ClassReporter>(dbContext);
            ClassRepository = new GenericRepository<Class>(dbContext);
            CommentRepository = new GenericRepository<Comment>(dbContext);
            CourseRepository = new GenericRepository<Course>(dbContext);
            LessonRepository = new GenericRepository<Lesson>(dbContext); ;
            ReporterRepository = new GenericRepository<Reporter>(dbContext);
            StudentClassRepository = new GenericRepository<StudentClass>(dbContext);
            StudentRepository = new GenericRepository<Student>(dbContext);
            TeacherRepository = new GenericRepository<Teacher>(dbContext);
        }

        public IGenericRepository<Admin> AdminRepository { get; }
        public IGenericRepository<Class> ClassRepository { get; }
        public IGenericRepository<ClassReporter> ClassReporterRepository { get; }
        public IGenericRepository<Comment> CommentRepository { get; }
        public IGenericRepository<Course> CourseRepository { get; }
        public IGenericRepository<Lesson> LessonRepository { get; }
        public IGenericRepository<Reporter> ReporterRepository { get; }
        public IGenericRepository<StudentClass> StudentClassRepository { get; }
        public IGenericRepository<Student> StudentRepository { get; }
        public IGenericRepository<Teacher> TeacherRepository { get; }

        public void Dispose() =>
            GC.SuppressFinalize(this);

        public async Task SaveAsync() =>
            await dbContext.SaveChangesAsync();
    }
}
}
