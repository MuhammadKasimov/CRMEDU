using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.ManyRelations;
using CRMEDU.Service.DTOs.ManyRelationsDTOs;
using CRMEDU.Service.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class StudentClassService : IStudentClassService
    {
        private readonly IUnitOfWork unitOfWork;
        private StudentClass studentClass;

        public StudentClassService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<StudentClass> CreateAsync(StudentClassForCreationDTO studentClassForCreationDTO)
        {
            studentClass = await unitOfWork.StudentClassRepository.CreateAsync(studentClassForCreationDTO.Adapt<StudentClass>());
            await unitOfWork.SaveAsync();
            return studentClass;
        }

        public async Task DeleteAsync(Expression<Func<StudentClass, bool>> expression)
        {
            if (!await unitOfWork.StudentClassRepository.DeleteAsync(expression))
                throw new Exception("relation between this class and student is empty");
            await unitOfWork.SaveAsync();
        }

        public IEnumerable<StudentClass> GetAllAsync(Expression<Func<StudentClass, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var studentClasses = unitOfWork.StudentClassRepository.GetAll(expression);
            return pagination == null
                ? studentClasses.Take(10)
                : (IEnumerable<StudentClass>)studentClasses.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }

        public async Task<StudentClass> GetAsync(Expression<Func<StudentClass, bool>> expression)
        {
            studentClass = await unitOfWork.StudentClassRepository.GetAsync(expression);
            return studentClass ?? throw new Exception("relation between this class and student is empty");
        }

        public async Task<StudentClass> UpdateAsync(long id, StudentClassForCreationDTO studentClassForCreationDTO)
        {
            studentClass = await GetAsync(s => s.Id == id);

            studentClass = unitOfWork.StudentClassRepository.Update(studentClassForCreationDTO.Adapt(studentClass));
            await unitOfWork.SaveAsync();
            return studentClass;
        }

    }
}
