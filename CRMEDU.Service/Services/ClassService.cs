using AutoMapper;
using CRMEDU.Data.IRepositories;
using CRMEDU.Data.Repositories;
using CRMEDU.Domain.Entities.Courses;
using CRMEDU.Service.DTOs.CoursesDTOs;
using CRMEDU.Service.Interfaces;
using CRMEDU.Service.Maper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository classRepository;
        private readonly IMapper mapper;
        private Class clas;

        public ClassService()
        {
            classRepository = new ClassRepository();
            mapper = new MapperConfiguration(
                cfg => cfg.AddProfile<MapingProfile>())
                .CreateMapper();
            clas = new Class();
        }
        public async Task<Class> CreateAsync(ClassForCreationDTO classForCreationDTO)
        {
            if (classForCreationDTO.ClassName.Length < 65)
                throw new Exception("Name of class should no more then 65 characters");
            clas = await classRepository.CreateAsync(mapper.Map<Class>(classForCreationDTO));
            await classRepository.SaveAsync();
            return clas;
        }

        public async Task DeleteAsync(Expression<Func<Class, bool>> expression)
        {
            if (await classRepository.DeleteAsync(expression))
                throw new Exception("Class not found");
            await classRepository.SaveAsync();
        }

        public IEnumerable<Class> GetAllAsync(Expression<Func<Class, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var classes = classRepository.GetAll(expression);
            if (pagination == null)
                return classes.Take(10);
            return classes.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }

        public async Task<Class> GetAsync(Expression<Func<Class, bool>> expression)
        {
            clas = await classRepository.GetAsync(expression);
            if (clas == null)
                throw new Exception("Class not found");
            return clas;
        }

        public async Task<Class> UpdateAsync(long id, ClassForCreationDTO classForCreationDTO)
        {
            clas = await GetAsync(c => c.Id == id);

            clas = classRepository.Update(mapper.Map(classForCreationDTO, clas));
            await classRepository.SaveAsync();
            return clas;
        }
    }
}