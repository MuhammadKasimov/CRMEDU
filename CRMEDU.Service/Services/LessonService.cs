using AutoMapper;
using CRMEDU.Data.Repositories;
using CRMEDU.Domain.Entities.Lessons;
using CRMEDU.Service.DTOs.LessonsDTOs;
using CRMEDU.Service.Interfaces;
using CRMEDU.Service.Maper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class LessonService : ILessonService
    {
        private readonly LessonRepository lessonRepository;
        private readonly IMapper mapper;
        private Lesson lesson;

        public LessonService()
        {
            lessonRepository = new LessonRepository();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapingProfile>();
            }).CreateMapper();
            lesson = new Lesson();
        }
        public async Task<Lesson> CreateAsync(LessonForCreationDTO lessonForCreationDTO)
        {
            if (lessonForCreationDTO.Title.Length > 80)
                throw new ArgumentException("Title cannot be longer than 80 characters");

            lesson = await lessonRepository.CreateAsync(mapper.Map<Lesson>(lessonForCreationDTO));
            await lessonRepository.SaveAsync();
            return lesson;
        }

        public async Task DeleteAsync(Expression<Func<Lesson, bool>> expression)
        {
            if (await lessonRepository.DeleteAsync(expression))
                throw new ArgumentException("Lesson not found");
            await lessonRepository.SaveAsync();
        }

        public IEnumerable<Lesson> GetAll(Expression<Func<Lesson, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var lessons = lessonRepository.GetAll(expression);
            if (pagination == null)
                return lessons.Take(10);
            return lessons.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }

        public async Task<Lesson> GetAsync(Expression<Func<Lesson, bool>> expression)
        {
            lesson = await lessonRepository.GetAsync(expression);
            if (lesson == null)
                throw new ArgumentException("Lesson not found");
            return lesson;
        }

        public async Task<Lesson> UpdateAsync(long id, LessonForCreationDTO lessonForCreationDTO)
        {
            lesson = await GetAsync(l => l.Id == id);

            lesson = lessonRepository.Update(mapper.Map(lessonForCreationDTO, lesson));
            await lessonRepository.SaveAsync();
            return lesson;
        }
    }
}
