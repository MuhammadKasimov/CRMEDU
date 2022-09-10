using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.Students;
using CRMEDU.Service.DTOs.StudentsDTOs;
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
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;
        Student student;
        public StudentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Student> CreateAsync(StudentForCreationDTO studentForCreationDTO)
        {
            if (!studentForCreationDTO.Basics.Security.Password.IsValidPassword())
                throw new Exception("Password should contain at least 8 chars" +
                    " at least one letter " +
                    "and at list one number");
            if (!studentForCreationDTO.Connection.Email.IsValidEmail())
                throw new Exception("Email can contain only numbers, letters, '.' and should end with @gmail.com");
            studentForCreationDTO.Basics.Security.Password.GetHashPasword();

            if (StringExtentions.IsNoMoreThenMaxSize(30, new string[]
            {
                studentForCreationDTO.Basics.LastName,
                studentForCreationDTO.Basics.FirstName,
                studentForCreationDTO.Basics.FathersName,
                studentForCreationDTO.Basics.Username
            }))
                throw new Exception("Name, FirstName, FathesName, UserName can contain only 30 chars");

            student = await unitOfWork.StudentRepository.CreateAsync(studentForCreationDTO.Adapt<Student>());
            await unitOfWork.SaveAsync();
            return student;
        }

        public async Task DeleteAsync(Expression<Func<Student, bool>> expression)
        {
            if (!await unitOfWork.StudentRepository.DeleteAsync(expression))
                throw new Exception("User not found");

            await unitOfWork.SaveAsync();
        }

        public IEnumerable<Student> GetAllAsync(Expression<Func<Student, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var admins = unitOfWork.StudentRepository.GetAll(expression);
            return pagination == null
                ? admins.Take(10)
                : (IEnumerable<Student>)admins.Skip((pagination.Item1 - 1) * pagination.Item2)
                      .Take(pagination.Item2);
        }

        public async Task<Student> GetAsync(Expression<Func<Student, bool>> expression)
        {
            student = await unitOfWork.StudentRepository.GetAsync(expression);
            return student ?? throw new Exception("Student not found");
        }

        public async Task<Student> UpdateAsync(long id, StudentForCreationDTO studentForCreationDTO)
        {
            student = await GetAsync(s => s.Id == id);

            student = unitOfWork.StudentRepository.Update(studentForCreationDTO.Adapt(student));
            await unitOfWork.SaveAsync();
            return student;
        }
    }
}