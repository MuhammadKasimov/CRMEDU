using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.Reporters;
using CRMEDU.Service.DTOs.ReportersDTOs;
using CRMEDU.Service.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class ReporterService : IReporterService
    {
        private readonly IUnitOfWork unitOfWork;
        private Reporter reporter;

        public ReporterService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Reporter> CreateAsync(ReporterForCreationDTO reporterForCreationDTO)
        {
            reporter = await unitOfWork.ReporterRepository.CreateAsync(reporterForCreationDTO.Adapt<Reporter>());
            return reporter;
        }

        public async Task DeleteAsync(Expression<Func<Reporter, bool>> expression)
        {
            if (!await unitOfWork.ReporterRepository.DeleteAsync(expression))
                throw new Exception("Reporter not found");
            await unitOfWork.SaveAsync();
        }

        public IEnumerable<Reporter> GetAll(Expression<Func<Reporter, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var reporters = unitOfWork.ReporterRepository.GetAll(expression);
            return pagination == null ? reporters.Take(10)
                : (IEnumerable<Reporter>)reporters
                .Skip((pagination.Item1 - 1) * pagination.Item2)
                .Take(pagination.Item2);
        }
        public async Task<Reporter> GetAsync(Expression<Func<Reporter, bool>> expression)
        {
            reporter = await unitOfWork.ReporterRepository.GetAsync(expression);
            return reporter ?? throw new Exception("Reporter not found");
        }

        public async Task<Reporter> UpdateAsync(long id, ReporterForCreationDTO reporterForCreationDTO)
        {
            reporter = await GetAsync(r => r.Id == id);

            reporter = unitOfWork.ReporterRepository.Update(
                reporterForCreationDTO.Adapt(reporter));
            return reporter;
        }
    }
}