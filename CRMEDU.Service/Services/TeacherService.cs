using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.Teachers;
using CRMEDU.Service.DTOs.TeachersDTOs;
using CRMEDU.Service.Exceptions;
using CRMEDU.Service.Extensions;
using CRMEDU.Service.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork unitOfWork;
        Teacher teacher;
        public TeacherService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Teacher> CreateAsync(TeacherForCreationDTO teacherForCreationDTO)
        {
            if (!teacherForCreationDTO.Basics.Security.Password.IsValidPassword())
                throw new MyCustomException("Password should contain at least 8 chars and no more then 50" +
                    " at least one letter " +
                    "and at list one number");
            if (!teacherForCreationDTO.Connection.Email.IsValidEmail())
                throw new MyCustomException("Email can contain only numbers, letters, '.' and should end with @gmail.com");

            if (StringExtentions.IsNoMoreThenMaxSize(
                30, new string[]
                {
                    teacherForCreationDTO.Basics.LastName,
                    teacherForCreationDTO.Basics.FirstName,
                    teacherForCreationDTO.Basics.FathersName,
                    teacherForCreationDTO.Basics.Username
                }))
                throw new MyCustomException("Name, FirstName, FathesName, UserName can contain only 30 chars");

            teacherForCreationDTO.Basics.Security.Password.GetHashPasword();

            teacher = await unitOfWork.TeacherRepository.CreateAsync(teacherForCreationDTO.Adapt<Teacher>());
            await unitOfWork.SaveAsync();
            return teacher;
        }

        public async Task DeleteAsync(Expression<Func<Teacher, bool>> expression)
        {
            if (!await unitOfWork.TeacherRepository.DeleteAsync(expression))
            {
                throw new MyCustomException("Teacher not found");
            }
            await unitOfWork.SaveAsync();
        }

        public IEnumerable<Teacher> GetAllAsync(Expression<Func<Teacher, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var admins = unitOfWork.TeacherRepository.GetAll(expression);
            return pagination == null
                ? admins.Take(10)
                : (IEnumerable<Teacher>)admins.Skip((pagination.Item1 - 1) * pagination.Item2)
                                              .Take(pagination.Item2);
        }

        public async Task<Teacher> GetAsync(Expression<Func<Teacher, bool>> expression)
        {
            teacher = await unitOfWork.TeacherRepository.GetAsync(expression);
            return teacher ?? throw new MyCustomException("Teacher not found");
        }

        public async Task<Teacher> UpdateAsync(long id, TeacherForCreationDTO teacherForCreationDTO)
        {
            teacher = await GetAsync(t => t.Id == id);
            teacher = unitOfWork.TeacherRepository.Update(teacherForCreationDTO.Adapt(teacher));
            await unitOfWork.SaveAsync();
            return teacher;
        }
    }
}

