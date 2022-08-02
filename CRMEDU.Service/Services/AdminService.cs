using AutoMapper;
using CRMEDU.Data.IRepositories;
using CRMEDU.Data.Repositories;
using CRMEDU.Domain.Entities.Admins;
using CRMEDU.Service.DTOs.AdminsDTOs;
using CRMEDU.Service.Extensions;
using CRMEDU.Service.Interfaces;
using CRMEDU.Service.Maper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository adminRepository;
        private readonly IMapper mapper;
        private Admin admin;

        public AdminService()
        {
            admin = new Admin();

            adminRepository = new AdminRepository();

            mapper = new MapperConfiguration
                (cfg =>
                {
                    cfg.AddProfile<MapingProfile>();
                }).CreateMapper();
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



            admin = await adminRepository.CreateAsync(mapper.Map<Admin>(adminForCreationDTO));

            try
            {
                await adminRepository.SaveAsync();
            }
            catch
            {
                throw new Exception("Username, Email, or such already exists");
            }
            return admin;
        }

        public async Task DeleteAsync(Expression<Func<Admin, bool>> expression)
        {
            if (!await adminRepository.DeleteAsync(expression))
                throw new Exception("Admin not found");

            await adminRepository.SaveAsync();
        }

        public IEnumerable<Admin> GetAll(Expression<Func<Admin, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var admins = adminRepository.GetAll(expression);

            return pagination == null
                ? admins.Take(10)
                : (IEnumerable<Admin>)admins.Skip((pagination.Item1 - 1) * pagination.Item2)
                      .Take(pagination.Item2);
        }

        public async Task<Admin> GetAsync(Expression<Func<Admin, bool>> expression)
        {
            admin = await adminRepository.GetAsync(expression);

            return admin ?? throw new Exception("Admin not found");
        }

        public async Task<Admin> UpdateAsync(long id, AdminForCreationDTO adminForCreationDTO)
        {
            admin = await GetAsync(a => a.Id == id);

            admin = adminRepository.Update(mapper.Map(adminForCreationDTO, admin));
            await adminRepository.SaveAsync();
            return admin;
        }
    }
}
