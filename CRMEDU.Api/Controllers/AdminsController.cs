using CRMEDU.Service.DTOs.AdminsDTOs;
using CRMEDU.Service.DTOs.CommonDTOs;
using CRMEDU.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRMEDU.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminsController(IAdminService adminService)
        {
            this.adminService = adminService;
        }


        [HttpGet, Authorize]
        public IActionResult Get()
        {
            return Ok(adminService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdminForCreationDTO adminForCreationDTO)
        {
            return Ok(await adminService.CreateAsync(adminForCreationDTO));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(SecurityForCreationDTO securityForCreationDTO)
        {
            var token = await adminService.GenerateTokenAsync(securityForCreationDTO.Login, securityForCreationDTO.Password);

            return Ok(new
            {
                Token = token
            });
        }


        [HttpGet, Route("Id"), Authorize]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await adminService.GetAsync(a => a.Id == id));
        }
    }
}
