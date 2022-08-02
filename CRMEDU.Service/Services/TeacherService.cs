using AutoMapper;
using CRMEDU.Data.IRepositories;
using CRMEDU.Data.Repositories;
using CRMEDU.Domain.Entities.Teachers;
using CRMEDU.Service.DTOs.TeachersDTOs;
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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;
        private readonly IMapper mapper;
        Teacher teacher;
        public TeacherService()
        {
            teacher = new Teacher();
            teacherRepository = new TeacherRepository();
            mapper = new MapperConfiguration
                (cfg =>
                {
                    cfg.AddProfile<MapingProfile>();
                }).CreateMapper();
        }

        public async Task<Teacher> CreateAsync(TeacherForCreationDTO teacherForCreationDTO)
        {
            if (!teacherForCreationDTO.Basics.Security.Password.IsValidPassword())
                throw new Exception("Password should contain at least 8 chars and no more then 50" +
                    " at least one letter " +
                    "and at list one number");
            if (!teacherForCreationDTO.Connection.Email.IsValidEmail())
                throw new Exception("Email can contain only numbers, letters, '.' and should end with @gmail.com");

            if (StringExtentions.IsNoMoreThenMaxSize(
                30, new string[]
                {
                    teacherForCreationDTO.Basics.LastName,
                    teacherForCreationDTO.Basics.FirstName,
                    teacherForCreationDTO.Basics.FathersName,
                    teacherForCreationDTO.Basics.Username
                }))
                throw new Exception("Name, FirstName, FathesName, UserName can contain only 30 chars");

            teacherForCreationDTO.Basics.Security.Password.GetHashPasword();

            teacher = await teacherRepository.CreateAsync(mapper.Map<Teacher>(teacherForCreationDTO));
            await teacherRepository.SaveAsync();
            return teacher;
        }

        public async Task DeleteAsync(Expression<Func<Teacher, bool>> expression)
        {
            if (!await teacherRepository.DeleteAsync(expression))
            {
                throw new Exception("Teacher not found");
            }
            await teacherRepository.SaveAsync();
        }

        public IEnumerable<Teacher> GetAllAsync(Expression<Func<Teacher, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var admins = teacherRepository.GetAll(expression);
            return pagination == null
                ? admins.Take(10)
                : (IEnumerable<Teacher>)admins.Skip((pagination.Item1 - 1) * pagination.Item2)
                                              .Take(pagination.Item2);
        }

        public async Task<Teacher> GetAsync(Expression<Func<Teacher, bool>> expression)
        {
            teacher = await teacherRepository.GetAsync(expression);
            return teacher ?? throw new Exception("Teacher not found");
        }

        public async Task<Teacher> UpdateAsync(long id, TeacherForCreationDTO teacherForCreationDTO)
        {
            teacher = await GetAsync(t => t.Id == id);
            teacher = teacherRepository.Update(mapper.Map(teacherForCreationDTO, teacher));
            await teacherRepository.SaveAsync();
            return teacher;
        }
    }
}

