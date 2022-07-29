using CRMEDU.Domain.Commons;
using CRMEDU.Service.DTOs.CommonDTOs;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Interfaces
{
    public interface ICommentService
    {

        Task<Comment> CreateAsync(CommentForCreationDTO commentForCreationDTO);

        Task<Comment> UpdateAsync(long id, CommentForCreationDTO commentForCreationDTO);

        Task DeleteAsync(Expression<Func<Comment, bool>> expression);

        Task<Comment> GetAsync(Expression<Func<Comment, bool>> expression);

        IQueryable<Comment> GetAllAsync(Expression<Func<Comment, bool>> expression = null, Tuple<int, int> pagination = null);

    }
}
