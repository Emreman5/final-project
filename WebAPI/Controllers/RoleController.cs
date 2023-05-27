using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var list = _roleManager.Roles.ToList();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddRole(string roleName)
        {
            _roleManager.CreateAsync(new IdentityRole(roleName)).Wait();
            return Ok();
        }
    }
}
