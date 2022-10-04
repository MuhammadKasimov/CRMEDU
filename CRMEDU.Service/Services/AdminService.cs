using CRMEDU.Data.IRepositories;
using CRMEDU.Domain.Entities.Admins;
using CRMEDU.Service.DTOs.AdminsDTOs;
using CRMEDU.Service.Exceptions;
using CRMEDU.Service.Extensions;
using CRMEDU.Service.Interfaces;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRMEDU.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork unitOfWork;
        private Admin admin;
        IConfiguration configuration;

        public AdminService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        public async Task<Admin> CreateAsync(AdminForCreationDTO adminForCreationDTO)
        {
            if (!adminForCreationDTO.Basics.Security.Password.IsValidPassword())
                throw new MyCustomException(message: "Password should contain at least 8 chars" +
                    " at least one letter " +
                    "and at list one number");


            if (!adminForCreationDTO.Connection.Email.IsValidEmail())
                throw new MyCustomException("Email can contain only numbers, letters, '.' and should end with @gmail.com");

            if (!StringExtentions.IsNoMoreThenMaxSize(
                30, new string[]
                {
                    adminForCreationDTO.Basics.LastName,
                    adminForCreationDTO.Basics.FirstName,
                    adminForCreationDTO.Basics.FathersName,
                    adminForCreationDTO.Basics.Username
                }))
                throw new MyCustomException("Name, FirstName, FathesName, UserName can contain only 30 chars");


            adminForCreationDTO.Basics.Security.Password = adminForCreationDTO.Basics.Security.Password.GetHashPasword();



            admin = await unitOfWork.AdminRepository.CreateAsync(adminForCreationDTO.Adapt<Admin>());
            await unitOfWork.SaveAsync();
            return admin;
        }

        public async Task DeleteAsync(Expression<Func<Admin, bool>> expression)
        {
            if (!await unitOfWork.AdminRepository.DeleteAsync(expression))
                throw new MyCustomException("Admin not found");

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

            return admin ?? throw new MyCustomException("Admin not found");
        }

        public async Task<Admin> UpdateAsync(long id, AdminForCreationDTO adminForCreationDTO)
        {
            admin = await GetAsync(a => a.Id == id);

            admin = unitOfWork.AdminRepository.Update(adminForCreationDTO.Adapt(admin));
            await unitOfWork.SaveAsync();
            return admin;
        }

        public async Task<string> GenerateTokenAsync(string login, string password)
        {
            var admin = await unitOfWork.AdminRepository.GetAsync(a =>
                a.Basics.Security.Login == login && a.Basics.Security.Password == password.GetHashPasword());

            if (admin is null)
                throw new MyCustomException("the password or login is incorrect");

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", admin.Id.ToString()),
                    new Claim("FirstName",admin.Basics.FirstName),
                    new Claim("Login",admin.Basics.Security.Login),
                    new Claim("LastName",admin.Basics.LastName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
