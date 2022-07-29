using CRMEDU.Domain.Entities.Courses;
using CRMEDU.Service.DTOs.CoursesDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Interfaces
{
    public interface ICourseService
    {
        Task<Course> CreateAsync(CourseForCreationDTO courseForCreationDTO);
        Task<Course> UpdateAsync(long id, Course courseForCreationDTO);
        Task DeleteAsync(Expression<Func<Course, bool>> expression);
        Task<Course> GetAsync(Expression<Func<Course, bool>> expression);
        IEnumerable<Course> GetAll(Expression<Func<Course, bool>> expression = null, Tuple<int, int> pagination = null);
    }
}
