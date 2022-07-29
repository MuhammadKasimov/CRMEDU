using CRMEDU.Domain.Entities.Teachers;
using CRMEDU.Service.DTOs.TeachersDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Interfaces
{
    public interface ITeacherService
    {

        Task<Teacher> CreateAsync(TeacherForCreationDTO teacherForCreationDTO);

        Task<Teacher> UpdateAsync(long id, TeacherForCreationDTO teacher);

        Task DeleteAsync(Expression<Func<Teacher, bool>> expression);

        Task<Teacher> GetAsync(Expression<Func<Teacher, bool>> expression);

        IEnumerable<Teacher> GetAllAsync(Expression<Func<Teacher, bool>> expression = null, Tuple<int, int> pagination = null);

    }
}
