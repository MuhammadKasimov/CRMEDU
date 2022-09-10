using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.Admins;
using CRMEDU.Service.DTOs.AdminsDTOs;
using CRMEDU.Service.Extensions;
using CRMEDU.Service.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork unitOfWork;
        private Admin admin;

        public AdminService(IUnitOfWork unitOfWork)
        {
            admin = new Admin();
            Console.WriteLine("AdminService");
        }

        public async Task<Admin> CreateAsync(AdminForCreationDTO adminForCreationDTO)
        {
            if (!adminForCreationDTO.Basics.Security.Password.IsValidPassword())
                throw new Exception(message: "Password should contain at least 8 chars" +
                    " at least one letter " +
                    "and at list one number");


            if (!adminForCreationDTO.Connection.Email.IsValidEmail())
                throw new Exception("Email can contain only numbers, letters, '.' and should end with @gmail.com");

            if (!StringExtentions.IsNoMoreThenMaxSize(
                30, new string[]
                {
                    adminForCreationDTO.Basics.LastName,
                    adminForCreationDTO.Basics.FirstName,
                    adminForCreationDTO.Basics.FathersName,
                    adminForCreationDTO.Basics.Username
                }))
                throw new Exception("Name, FirstName, FathesName, UserName can contain only 30 chars");


            adminForCreationDTO.Basics.Security.Password = adminForCreationDTO.Basics.Security.Password.GetHashPasword();



            admin = await unitOfWork.AdminRepository.CreateAsync(adminForCreationDTO.Adapt<Admin>());

            try
            {
                await unitOfWork.SaveAsync();
            }
            catch
            {
                throw new Exception("Username, Email, or such already exists");
            }
            return admin;
        }

        public async Task DeleteAsync(Expression<Func<Admin, bool>> expression)
        {
            if (!await unitOfWork.AdminRepository.DeleteAsync(expression))
                throw new Exception("Admin not found");

            await unitOfWork.SaveAsync();
        }

        public IEnumerable<Admin> GetAll(Expression<Func<Admin, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var admins = unitOfWork.AdminRepository.GetAll(expression);

            return pagination == null
                ? admins.Take(10)
                : (IEnumerable<Admin>)admins.Skip((pagination.Item1 - 1) * pagination.Item2)
                      .Take(pagination.Item2);
        }

        public async Task<Admin> GetAsync(Expression<Func<Admin, bool>> expression)
        {
            admin = await unitOfWork.AdminRepository.GetAsync(expression);

            return admin ?? throw new Exception("Admin not found");
        }

        public async Task<Admin> UpdateAsync(long id, AdminForCreationDTO adminForCreationDTO)
        {
            admin = await GetAsync(a => a.Id == id);

            admin = unitOfWork.AdminRepository.Update(adminForCreationDTO.Adapt(admin));
            await unitOfWork.SaveAsync();
            return admin;
        }
    }
}
