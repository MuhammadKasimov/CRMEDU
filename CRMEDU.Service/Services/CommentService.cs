using AutoMapper;
using CRMEDU.Data.IRepositories;
using CRMEDU.Data.Repositories;
using CRMEDU.Domain.Commons;
using CRMEDU.Service.DTOs.CommonDTOs;
using CRMEDU.Service.Interfaces;
using CRMEDU.Service.Maper;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper mapper;
        private Comment comment;
        public CommentService()
        {
            commentRepository = new CommentRepository();
            mapper = new MapperConfiguration(
                cfg => cfg.AddProfile<MapingProfile>())
                .CreateMapper();
            comment = new Comment();
        }

        public async Task<Comment> CreateAsync(CommentForCreationDTO commentForCreationDTO)
        {
            if (commentForCreationDTO.Context.Length < 500)
                throw new Exception("Context can't more then 500 chracters");
            comment = await commentRepository.CreateAsync(mapper.Map<Comment>(commentForCreationDTO));
            await commentRepository.SaveAsync();
            return comment;
        }

        public async Task DeleteAsync(Expression<Func<Comment, bool>> expression)
        {
            if (!await commentRepository.DeleteAsync(expression))
                throw new Exception("Comment not found");
            await commentRepository.SaveAsync();
        }

        public IQueryable<Comment> GetAllAsync(Expression<Func<Comment, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var comments = commentRepository.GetAll(expression);
            return pagination == null ? comments.Take(10) : comments.Skip((pagination.Item1 - 1) * pagination.Item2).Take(pagination.Item2);
        }

        public async Task<Comment> GetAsync(Expression<Func<Comment, bool>> expression)
        {
            comment = await commentRepository.GetAsync(expression);
            return comment ?? throw new Exception("Comment not found");
        }

        public async Task<Comment> UpdateAsync(long id, CommentForCreationDTO commentForCreationDTO)
        {
            comment = await GetAsync(c => c.Id == id);

            comment = commentRepository.Update(mapper.Map(commentForCreationDTO, comment));
            await commentRepository.SaveAsync();
            return comment;
        }
    }
}
