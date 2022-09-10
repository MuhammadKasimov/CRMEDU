using CRMEDU.Service.Interfaces;
using CRMEDU.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRMEDU.Api.Controllers
{

    [ApiController, Route("api/[controller]")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminsController()
        {
            adminService = new AdminService();
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(adminService.GetAll());
        }
    }
}
