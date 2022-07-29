using CRMEDU.Domain.Entities.ManyRelations;
using CRMEDU.Service.DTOs.ManyRelationsDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Interfaces
{
    public interface IClassReporterService
    {
        Task<ClassReporter> CreateAsync(ClassReporterForCreationDTO classReporterForCreationDTO);

        Task<ClassReporter> UpdateAsync(long id, ClassReporterForCreationDTO classReporterForCreationDTO);

        Task DeleteAsync(Expression<Func<ClassReporter, bool>> expression);

        Task<ClassReporter> GetAsync(Expression<Func<ClassReporter, bool>> expression);

        IEnumerable<ClassReporter> GetAll(Expression<Func<ClassReporter, bool>> expression = null, Tuple<int, int> pagination = null);

    }
}
