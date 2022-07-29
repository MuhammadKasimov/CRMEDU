using AutoMapper;
using CRMEDU.Data.IRepositories;
using CRMEDU.Data.Repositories;
using CRMEDU.Domain.Entities.ManyRelations;
using CRMEDU.Service.DTOs.ManyRelationsDTOs;
using CRMEDU.Service.Interfaces;
using CRMEDU.Service.Maper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class ClassReporterService : IClassReporterService
    {
        private readonly IClassReporterRepository classReporterRepository;
        private readonly IMapper mapper;
        private ClassReporter classReporter;

        public ClassReporterService()
        {
            classReporterRepository = new ClassReporterRepository();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapingProfile>();
            }).CreateMapper();
        }

        public async Task<ClassReporter> CreateAsync(ClassReporterForCreationDTO ClassReporterForCreationDTO)
        {
            classReporter = await classReporterRepository.CreateAsync(mapper.Map<ClassReporter>(ClassReporterForCreationDTO));
            return classReporter;
        }

        public async Task DeleteAsync(Expression<Func<ClassReporter, bool>> expression)
        {
            if (!await classReporterRepository.DeleteAsync(expression))
                throw new Exception("ClassReporter not found");
            await classReporterRepository.SaveAsync();
        }

        public IEnumerable<ClassReporter> GetAll(Expression<Func<ClassReporter, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var reporters = classReporterRepository.GetAll(expression);
            if (pagination == null)
                return reporters.Take(10);
            return reporters.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }
        public async Task<ClassReporter> GetAsync(Expression<Func<ClassReporter, bool>> expression)
        {
            classReporter = await classReporterRepository.GetAsync(expression);
            if (classReporter == null)
                throw new Exception("Reporter not found");
            return classReporter;
        }

        public async Task<ClassReporter> UpdateAsync(long id, ClassReporterForCreationDTO reporterForCreationDTO)
        {
            classReporter = await GetAsync(r => r.Id == id);

            classReporter = classReporterRepository.Update(
                mapper.Map(reporterForCreationDTO, classReporter));
            return classReporter;
        }
    }
}
