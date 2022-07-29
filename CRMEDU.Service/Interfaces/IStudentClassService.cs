using CRMEDU.Domain.Entities.ManyRelations;
using CRMEDU.Service.DTOs.ManyRelationsDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Interfaces
{
    public interface IStudentClassService
    {

        Task<StudentClass> CreateAsync(StudentClassForCreationDTO studentClassForCreationDTO);

        Task<StudentClass> UpdateAsync(long id, StudentClassForCreationDTO studentClassForCreationDTO);

        Task DeleteAsync(Expression<Func<StudentClass, bool>> expression);

        Task<StudentClass> GetAsync(Expression<Func<StudentClass, bool>> expression);

        IEnumerable<StudentClass> GetAllAsync(Expression<Func<StudentClass, bool>> expression = null, Tuple<int, int> pagination = null);

    }
}
