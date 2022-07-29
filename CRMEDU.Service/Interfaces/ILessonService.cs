using CRMEDU.Domain.Entities.Lessons;
using CRMEDU.Service.DTOs.LessonsDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Interfaces
{
    public interface ILessonService
    {

        Task<Lesson> CreateAsync(LessonForCreationDTO lessonForCreationDTO);

        Task<Lesson> UpdateAsync(long id, LessonForCreationDTO lessonForCreationDTO);

        Task DeleteAsync(Expression<Func<Lesson, bool>> expression);

        Task<Lesson> GetAsync(Expression<Func<Lesson, bool>> expression);

        IEnumerable<Lesson> GetAll(Expression<Func<Lesson, bool>> expression = null, Tuple<int, int> pagination = null);

    }
}
