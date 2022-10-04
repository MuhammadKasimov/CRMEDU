using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.ManyRelations;
using CRMEDU.Service.DTOs.ManyRelationsDTOs;
using CRMEDU.Service.Exceptions;
using CRMEDU.Service.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class ClassReporterService : IClassReporterService
    {
        private readonly IUnitOfWork unitOfWork;
        private ClassReporter classReporter;

        public ClassReporterService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ClassReporter> CreateAsync(ClassReporterForCreationDTO classReporterForCreationDTO)
        {
            classReporter = await unitOfWork.ClassReporterRepository.CreateAsync(classReporterForCreationDTO.Adapt<ClassReporter>());
            return classReporter;
        }

        public async Task DeleteAsync(Expression<Func<ClassReporter, bool>> expression)
        {
            if (!await unitOfWork.ClassReporterRepository.DeleteAsync(expression))
                throw new MyCustomException("ClassReporter not found");
            await unitOfWork.SaveAsync();
        }

        public IEnumerable<ClassReporter> GetAll(Expression<Func<ClassReporter, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var reporters = unitOfWork.ClassReporterRepository.GetAll(expression);
            return pagination == null ? reporters.Take(10) :
                (IEnumerable<ClassReporter>)reporters
                .Skip((pagination.Item1 - 1) * pagination.Item2)
                .Take(pagination.Item2);
        }
        public async Task<ClassReporter> GetAsync(Expression<Func<ClassReporter, bool>> expression)
        {
            classReporter = await unitOfWork.ClassReporterRepository.GetAsync(expression);
            return classReporter ?? throw new MyCustomException("Reporter not found");
        }

        public async Task<ClassReporter> UpdateAsync(long id, ClassReporterForCreationDTO classReporterForCreationDTO)
        {
            classReporter = await GetAsync(r => r.Id == id);

            classReporter = unitOfWork.ClassReporterRepository.Update(
                classReporterForCreationDTO.Adapt(classReporter));
            return classReporter;
        }
    }
}
