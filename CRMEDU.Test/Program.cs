using CRMEDU.Service.Interfaces;
using CRMEDU.Service.Services;

namespace CRMEDU.Test
{
    public class Program
    {
        static void Main()
        {
            IAdminService adminService = new AdminService();
            IStudentService studentService = new StudentService();
            ITeacherService teacherService = new TeacherService();
            IClassService classService = new ClassService();
            IClassReporterService classReporterService = new ClassReporterService();
            ICommentService commentService = new CommentService();
            ICourseService courseService = new CourseService();
            IStudentClassService studentClassService = new StudentClassService();
            ILessonService lessonService = new LessonService();
            IReporterService reporterServices = new ReporterService();
        }
    }
}