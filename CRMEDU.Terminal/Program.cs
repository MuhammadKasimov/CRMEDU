using CRMEDU.Domain.Enums;
using CRMEDU.Service.DTOs.AdminsDTOs;
using CRMEDU.Service.DTOs.CommonDTOs;
using CRMEDU.Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMEDU.Terminal
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AdminService adminService = new AdminService();
            await adminService.CreateAsync(new AdminForCreationDTO()
            {
                Basics = new BasicsForCreationDTO()
                {
                    FathersName = "snkdsksd",
                    FirstName = "snksksds",
                    LastName = "sskdss",
                    Gender = Gender.Male,
                    DateOfBirth = DateTime.UtcNow,
                    Username = "ssdsdhhhhsds",
                    Security = new SecurityForCreationDTO()
                    {
                        Login = "mlssdffdddldkls",
                        Password = "hhkbjljlbjjjlnljjl"
                    },
                    SentComments = new List<CommentForCreationDTO>()
                    {
                        new CommentForCreationDTO()
                        {
                            Context = "msksskdslkcmdsklc",
                            SentTo = SentTo.Student
                        }
                    }
                },
                Connection = new ConnectionForCreationDTO()
                {
                    Address = "slslsslls",
                    Email = "dsdsds@gmail.com",
                    Phone = "smsllsmsms",
                    TgUserName = "smfdfddlmslmdsl"
                }
            });
        }
    }
}
