using AutoMapper;
using CRMEDU.Data.IRepositories;
using CRMEDU.Data.Repositories;
using CRMEDU.Domain.Entities.Courses;
using CRMEDU.Service.DTOs.CoursesDTOs;
using CRMEDU.Service.Interfaces;
using CRMEDU.Service.Maper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IMapper mapper;
        private Course course;
        public CourseService()
        {
            courseRepository = new CourseRepository();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapingProfile>();
            }).CreateMapper();
            course = new Course();
        }
        public async Task<Course> CreateAsync(CourseForCreationDTO courseForCreationDTO)
        {
            if (courseForCreationDTO.Title.Length > 65)
                throw new Exception("Title length can't be more then 65 characters");
            try
            {
                course = await courseRepository.CreateAsync(mapper.Map<Course>(courseForCreationDTO));
            }
            catch (SqlException)
            {
                throw new Exception("Course Already Exists");
            }
            await courseRepository.SaveAsync();
            return course;
        }

        public async Task DeleteAsync(Expression<Func<Course, bool>> expression)
        {
            if (!await courseRepository.DeleteAsync(expression))
                throw new Exception("Course Not Found");
            await courseRepository.SaveAsync();
        }

        public IEnumerable<Course> GetAll(Expression<Func<Course, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var courses = courseRepository.GetAll(expression);
            return pagination == null ? courses.Take(10) : (IEnumerable<Course>)courses.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }

        public async Task<Course> GetAsync(Expression<Func<Course, bool>> expression)
        {
            course = await courseRepository.GetAsync(expression);
            return course ?? throw new Exception("Course Not Found");
        }

        public async Task<Course> UpdateAsync(long id, Course courseForCreationDTO)
        {
            course = await GetAsync(c => c.Id == id);

            courseRepository.Update(mapper.Map(courseForCreationDTO, course));
            await courseRepository.SaveAsync();
            return course;
        }
    }
}
