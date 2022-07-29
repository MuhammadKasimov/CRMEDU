using AutoMapper;
using CRMEDU.Data.IRepositories;
using CRMEDU.Data.Repositories;
using CRMEDU.Domain.Entities.Students;
using CRMEDU.Service.DTOs.StudentsDTOs;
using CRMEDU.Service.Extensions;
using CRMEDU.Service.Interfaces;
using CRMEDU.Service.Maper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        Student student;
        public StudentService()
        {
            student = new Student();
            studentRepository = new StudentRepository();
            mapper = new MapperConfiguration
                (cfg =>
                {
                    cfg.AddProfile<MapingProfile>();
                }).CreateMapper();
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

            student = await studentRepository.CreateAsync(mapper.Map<Student>(studentForCreationDTO));
            await studentRepository.SaveAsync();
            return student;
        }

        public async Task DeleteAsync(Expression<Func<Student, bool>> expression)
        {
            if (!await studentRepository.DeleteAsync(expression))
            {
                throw new Exception("User not found");
            }
            await studentRepository.SaveAsync();
        }

        public IEnumerable<Student> GetAllAsync(Expression<Func<Student, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var admins = studentRepository.GetAll(expression);
            if (pagination == null)

                return admins.Take(10);
            else
                return admins.Skip((pagination.Item1 - 1) * pagination.Item2)
                      .Take(pagination.Item2);
        }

        public async Task<Student> GetAsync(Expression<Func<Student, bool>> expression)
        {
            student = await studentRepository.GetAsync(expression);
            if (student == null)
                throw new Exception("Student not found");
            return student;
        }

        public async Task<Student> UpdateAsync(long id, StudentForCreationDTO adminForCreationDTO)
        {
            student = await GetAsync(s => s.Id == id);

            student = studentRepository.Update(mapper.Map(adminForCreationDTO, student));
            await studentRepository.SaveAsync();
            return student;
        }
    }
}