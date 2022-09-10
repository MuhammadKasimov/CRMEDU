using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Commons;
using CRMEDU.Service.DTOs.CommonDTOs;
using CRMEDU.Service.Interfaces;
using Mapster;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        private Comment comment;
        public CommentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Comment> CreateAsync(CommentForCreationDTO commentForCreationDTO)
        {
            if (commentForCreationDTO.Context.Length < 500)
                throw new Exception("Context can't more then 500 chracters");
            comment = await unitOfWork.CommentRepository.CreateAsync(commentForCreationDTO.Adapt<Comment>());
            await unitOfWork.SaveAsync();
            return comment;
        }

        public async Task DeleteAsync(Expression<Func<Comment, bool>> expression)
        {
            if (!await unitOfWork.CommentRepository.DeleteAsync(expression))
                throw new Exception("Comment not found");
            await unitOfWork.SaveAsync();
        }

        public IQueryable<Comment> GetAllAsync(Expression<Func<Comment, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var comments = unitOfWork.CommentRepository.GetAll(expression);
            return pagination == null ? comments.Take(10) : comments.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }

        public async Task<Comment> GetAsync(Expression<Func<Comment, bool>> expression)
        {
            comment = await unitOfWork.CommentRepository.GetAsync(expression);
            return comment ?? throw new Exception("Comment not found");
        }

        public async Task<Comment> UpdateAsync(long id, CommentForCreationDTO commentForCreationDTO)
        {
            comment = await GetAsync(c => c.Id == id);

            comment = unitOfWork.CommentRepository.Update(commentForCreationDTO.Adapt(comment));
            await unitOfWork.SaveAsync();
            return comment;
        }
    }
}
