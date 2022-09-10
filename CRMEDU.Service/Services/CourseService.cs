using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.Courses;
using CRMEDU.Service.DTOs.CoursesDTOs;
using CRMEDU.Service.Interfaces;
using Mapster;
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
        private readonly IUnitOfWork unitOfWork;
        private Course course;
        public CourseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Course> CreateAsync(CourseForCreationDTO courseForCreationDTO)
        {
            if (courseForCreationDTO.Title.Length > 65)
                throw new Exception("Title length can't be more then 65 characters");
            try
            {
                course = await unitOfWork.CourseRepository.CreateAsync(courseForCreationDTO.Adapt<Course>());
            }
            catch (SqlException)
            {
                throw new Exception("Course Already Exists");
            }
            await unitOfWork.SaveAsync();
            return course;
        }

        public async Task DeleteAsync(Expression<Func<Course, bool>> expression)
        {
            if (!await unitOfWork.CourseRepository.DeleteAsync(expression))
                throw new Exception("Course Not Found");
            await unitOfWork.SaveAsync();
        }

        public IEnumerable<Course> GetAll(Expression<Func<Course, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var courses = unitOfWork.CourseRepository.GetAll(expression);
            return pagination == null ? courses.Take(10) : (IEnumerable<Course>)courses.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }

        public async Task<Course> GetAsync(Expression<Func<Course, bool>> expression)
        {
            course = await unitOfWork.CourseRepository.GetAsync(expression);
            return course ?? throw new Exception("Course Not Found");
        }

        public async Task<Course> UpdateAsync(long id, Course courseForCreationDTO)
        {
            course = await GetAsync(c => c.Id == id);

            unitOfWork.CourseRepository.Update(courseForCreationDTO.Adapt(course));
            await unitOfWork.SaveAsync();
            return course;
        }
    }
}
