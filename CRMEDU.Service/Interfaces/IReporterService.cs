using CRMEDU.Domain.Entities.Reporters;
using CRMEDU.Service.DTOs.ReportersDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Interfaces
{
    public interface IReporterService
    {

        Task<Reporter> CreateAsync(ReporterForCreationDTO reporterForCreationDTO);

        Task<Reporter> UpdateAsync(long id, ReporterForCreationDTO reporterForCreationDTO);

        Task DeleteAsync(Expression<Func<Reporter, bool>> expression);

        Task<Reporter> GetAsync(Expression<Func<Reporter, bool>> expression);

        IEnumerable<Reporter> GetAll(Expression<Func<Reporter, bool>> expression = null, Tuple<int, int> pagination = null);

    }
}
