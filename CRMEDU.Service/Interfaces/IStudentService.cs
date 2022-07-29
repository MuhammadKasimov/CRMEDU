using CRMEDU.Domain.Entities.Students;
using CRMEDU.Service.DTOs.StudentsDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Interfaces
{
    public interface IStudentService
    {

        Task<Student> CreateAsync(StudentForCreationDTO adminForCreationDTO);
        Task<Student> UpdateAsync(long id, StudentForCreationDTO adminForCreationDTO);
        Task DeleteAsync(Expression<Func<Student, bool>> expression);
        Task<Student> GetAsync(Expression<Func<Student, bool>> expression);
        IEnumerable<Student> GetAllAsync(Expression<Func<Student, bool>> expression = null, Tuple<int, int> pagination = null);
    }
}
