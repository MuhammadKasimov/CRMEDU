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
    public class StudentClassService : IStudentClassService
    {
        private readonly IStudentClassRepository studentClassRepository;
        private readonly IMapper mapper;
        private StudentClass studentClass;

        public StudentClassService()
        {
            studentClassRepository = new StudentClassRepository();
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapingProfile>()));
            studentClass = new StudentClass();
        }

        public async Task<StudentClass> CreateAsync(StudentClassForCreationDTO studentClassForCreationDTO)
        {
            studentClass = await studentClassRepository.CreateAsync(mapper.Map<StudentClass>(studentClassForCreationDTO));
            await studentClassRepository.SaveAsync();
            return studentClass;
        }

        public async Task DeleteAsync(Expression<Func<StudentClass, bool>> expression)
        {
            if (!await studentClassRepository.DeleteAsync(expression))
                throw new Exception("relation between this class and student is empty");
            await studentClassRepository.SaveAsync();
        }

        public IEnumerable<StudentClass> GetAllAsync(Expression<Func<StudentClass, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var studentClasses = studentClassRepository.GetAll(expression);
            if (pagination == null)
                return studentClasses.Take(10);
            return studentClasses.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }

        public async Task<StudentClass> GetAsync(Expression<Func<StudentClass, bool>> expression)
        {
            studentClass = await studentClassRepository.GetAsync(expression);
            if (studentClass == null)
                throw new Exception("relation between this class and student is empty");
            return studentClass;
        }

        public async Task<StudentClass> UpdateAsync(long id, StudentClassForCreationDTO studentClassForCreationDTO)
        {
            studentClass = await GetAsync(s => s.Id == id);

            studentClass = studentClassRepository.Update(mapper.Map<StudentClass>(studentClassForCreationDTO));
            await studentClassRepository.SaveAsync();
            return studentClass;
        }

    }
}
