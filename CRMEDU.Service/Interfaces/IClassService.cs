using CRMEDU.Domain.Entities.Courses;
using CRMEDU.Service.DTOs.CoursesDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Interfaces
{
    public interface IClassService
    {
        Task<Class> CreateAsync(ClassForCreationDTO classForCreationDTO);
        Task<Class> UpdateAsync(long id, ClassForCreationDTO classForCreationDTO);
        Task DeleteAsync(Expression<Func<Class, bool>> expression);
        Task<Class> GetAsync(Expression<Func<Class, bool>> expression);
        IEnumerable<Class> GetAllAsync(Expression<Func<Class, bool>> expression = null, Tuple<int, int> pagination = null);
    }
}
