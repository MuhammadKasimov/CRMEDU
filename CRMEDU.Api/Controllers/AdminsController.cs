using CRMEDU.Service.Interfaces;
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


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(adminService.GetAll());
        }
    }
}
