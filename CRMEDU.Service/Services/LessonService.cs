using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.Lessons;
using CRMEDU.Service.DTOs.LessonsDTOs;
using CRMEDU.Service.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork unitOfWork;
        private Lesson lesson;

        public LessonService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Lesson> CreateAsync(LessonForCreationDTO lessonForCreationDTO)
        {
            if (lessonForCreationDTO.Title.Length > 80)
                throw new ArgumentException("Title cannot be longer than 80 characters");

            lesson = await unitOfWork.LessonRepository.CreateAsync(lessonForCreationDTO.Adapt<Lesson>());
            await unitOfWork.SaveAsync();
            return lesson;
        }

        public async Task DeleteAsync(Expression<Func<Lesson, bool>> expression)
        {
            if (await unitOfWork.LessonRepository.DeleteAsync(expression))
                throw new ArgumentException("Lesson not found");
            await unitOfWork.SaveAsync();
        }

        public IEnumerable<Lesson> GetAll(Expression<Func<Lesson, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var lessons = unitOfWork.LessonRepository.GetAll(expression);
            return pagination == null ? lessons.Take(10) : (IEnumerable<Lesson>)lessons.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }

        public async Task<Lesson> GetAsync(Expression<Func<Lesson, bool>> expression)
        {
            lesson = await unitOfWork.LessonRepository.GetAsync(expression);
            return lesson ?? throw new ArgumentException("Lesson not found");
        }

        public async Task<Lesson> UpdateAsync(long id, LessonForCreationDTO lessonForCreationDTO)
        {
            lesson = await GetAsync(l => l.Id == id);

            lesson = unitOfWork.LessonRepository.Update(lessonForCreationDTO.Adapt(lesson));
            await unitOfWork.SaveAsync();
            return lesson;
        }
    }
}
