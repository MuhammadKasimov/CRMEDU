using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.Courses;
using CRMEDU.Service.DTOs.CoursesDTOs;
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
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork unitOfWork;
        private Class clas;

        public ClassService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Class> CreateAsync(ClassForCreationDTO classForCreationDTO)
        {
            if (classForCreationDTO.ClassName.Length < 65)
                throw new MyCustomException("Name of class should be no more then 65 characters");
            clas = await unitOfWork.ClassRepository.CreateAsync(classForCreationDTO.Adapt<Class>());
            await unitOfWork.SaveAsync();
            return clas;
        }

        public async Task DeleteAsync(Expression<Func<Class, bool>> expression)
        {
            if (await unitOfWork.ClassRepository.DeleteAsync(expression))
                throw new MyCustomException("Class not found");
            await unitOfWork.SaveAsync();
        }

        public IEnumerable<Class> GetAllAsync(Expression<Func<Class, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var classes = unitOfWork.ClassRepository.GetAll(expression);
            return pagination == null ? classes.Take(10) : (IEnumerable<Class>)classes.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }

        public async Task<Class> GetAsync(Expression<Func<Class, bool>> expression)
        {
            clas = await unitOfWork.ClassRepository.GetAsync(expression);
            return clas ?? throw new MyCustomException("Class not found");
        }

        public async Task<Class> UpdateAsync(long id, ClassForCreationDTO classForCreationDTO)
        {
            clas = await GetAsync(c => c.Id == id);

            clas = unitOfWork.ClassRepository.Update(classForCreationDTO.Adapt(clas));
            await unitOfWork.SaveAsync();
            return clas;
        }
    }
}