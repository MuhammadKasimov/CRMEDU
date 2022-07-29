using AutoMapper;
using CRMEDU.Data.IRepositories;
using CRMEDU.Data.Repositories;
using CRMEDU.Domain.Entities.Reporters;
using CRMEDU.Service.DTOs.ReportersDTOs;
using CRMEDU.Service.Interfaces;
using CRMEDU.Service.Maper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class ReporterService : IReporterService
    {
        private readonly IReporterRepository reporterRepository;
        private readonly IMapper mapper;
        private Reporter reporter;

        public ReporterService()
        {
            reporterRepository = new ReporterRepository();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapingProfile>();
            }).CreateMapper();
        }

        public async Task<Reporter> CreateAsync(ReporterForCreationDTO reporterForCreationDTO)
        {
            reporter = await reporterRepository.CreateAsync(mapper.Map<Reporter>(reporterForCreationDTO));
            return reporter;
        }

        public async Task DeleteAsync(Expression<Func<Reporter, bool>> expression)
        {
            if (!await reporterRepository.DeleteAsync(expression))
                throw new Exception("Reporter not found");
            await reporterRepository.SaveAsync();
        }

        public IEnumerable<Reporter> GetAll(Expression<Func<Reporter, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var reporters = reporterRepository.GetAll(expression);
            if (pagination == null)
                return reporters.Take(10);
            return reporters.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }
        public async Task<Reporter> GetAsync(Expression<Func<Reporter, bool>> expression)
        {
            reporter = await reporterRepository.GetAsync(expression);
            if (reporter == null)
                throw new Exception("Reporter not found");
            return reporter;
        }

        public async Task<Reporter> UpdateAsync(long id, ReporterForCreationDTO reporterForCreationDTO)
        {
            reporter = await GetAsync(r => r.Id == id);

            reporter = reporterRepository.Update(
                mapper.Map(reporterForCreationDTO, reporter));
            return reporter;
        }
    }
}