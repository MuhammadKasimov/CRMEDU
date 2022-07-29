using CRMEDU.Domain.Commons;
using CRMEDU.Domain.Entities.Admins;
using CRMEDU.Domain.Entities.Courses;
using CRMEDU.Domain.Entities.Lessons;
using CRMEDU.Domain.Entities.ManyRelations;
using CRMEDU.Domain.Entities.Reporters;
using CRMEDU.Domain.Entities.Students;
using CRMEDU.Domain.Entities.Teachers;
using Microsoft.EntityFrameworkCore;
namespace CRMEDU.Data.Context
{
    public class CRMEDUDBContext : DbContext
    {
        protected virtual DbSet<Comment> Comments { get; set; }
        protected virtual DbSet<Basics> Basics { get; set; }
        protected virtual DbSet<Teacher> Teachers { get; set; }
        protected virtual DbSet<Admin> Admins { get; set; }
        protected virtual DbSet<Class> Classes { get; set; }
        protected virtual DbSet<Course> Courses { get; set; }
        protected virtual DbSet<Lesson> Lessons { get; set; }
        protected virtual DbSet<Reporter> Reporters { get; set; }
        protected virtual DbSet<Student> Students { get; set; }
        protected virtual DbSet<Security> Security { get; set; }
        protected virtual DbSet<Connection> Connections { get; set; }
        protected virtual DbSet<StudentClass> StudentClasses { get; set; }
        protected virtual DbSet<ClassReporter> ClassReporters { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            string path = "Host=localhost;" +
                "Port=5432;" +
                "Database=\"CrmEdu\";" +
                "Username=postgres;" +
                "Password=muham1812";
            dbContextOptionsBuilder.UseNpgsql(path);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Connection>()
                        .HasIndex(c => c.Email)
                        .IsUnique(true);

            modelBuilder.Entity<Basics>()
                        .HasIndex(b => b.Username)
                        .IsUnique(true);

            modelBuilder.Entity<Course>()
                        .HasIndex(c => c.Title)
                        .IsUnique(true);

            modelBuilder.Entity<Security>()
                        .HasIndex(s => s.Login)
                        .IsUnique(true);

            modelBuilder.Entity<Student>()
                        .HasIndex(s => s.BasicsId)
                        .IsUnique(true);

            modelBuilder.Entity<Teacher>()
                        .HasIndex(t => t.BasicsId)
                        .IsUnique(true);

            modelBuilder.Entity<Admin>()
                        .HasIndex(a => a.BasicsId)
                        .IsUnique(true);

            modelBuilder.Entity<Admin>()
                        .HasIndex(a => a.ConnectionId)
                        .IsUnique(true);

            modelBuilder.Entity<Student>()
                        .HasIndex(s => s.ConnectionId)
                        .IsUnique(true);

            modelBuilder.Entity<Teacher>()
                        .HasIndex(t => t.ConnectionId)
                        .IsUnique(true);

            modelBuilder.Entity<Class>()
                        .HasIndex(c => c.ClassName)
                        .IsUnique(true);
        }
    }
}
