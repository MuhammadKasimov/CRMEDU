using CRMEDU.Domain.Entities.Admins;
using CRMEDU.Service.DTOs.AdminsDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Interfaces
{
    public interface IAdminService
    {
        Task<Admin> CreateAsync(AdminForCreationDTO adminForCreationDTO);
        Task<Admin> UpdateAsync(long id, AdminForCreationDTO adminForCreationDTO);
        Task DeleteAsync(Expression<Func<Admin, bool>> expression);
        Task<Admin> GetAsync(Expression<Func<Admin, bool>> expression);
        IEnumerable<Admin> GetAll(Expression<Func<Admin, bool>> expression = null, Tuple<int, int> pagination = null);
    }
}
