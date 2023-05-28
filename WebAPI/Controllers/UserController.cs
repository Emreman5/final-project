using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserManager<CustomUser> _userManager;

        public UserController(UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateDto dto)
        {
            var selectedUser = await _userManager.FindByIdAsync(dto.Id);
            
            if (selectedUser == null)
            {
                return BadRequest("User bulunamadı");
            }
            selectedUser.Fullname = dto.FullName;
            
            if (dto.Username != selectedUser.UserName && await _userManager.FindByNameAsync(dto.Username) != null)
            {
                return BadRequest("Böyle bir kullanıcı var");
            }
            selectedUser.UserName = dto.Username;
            selectedUser.Email = dto.Email;
            if (dto.Password is not null)
            {
                await _userManager.RemovePasswordAsync(selectedUser);
                await _userManager.AddPasswordAsync(selectedUser ,dto.Password);
            }
            await _userManager.UpdateAsync(selectedUser);
            return Ok("user güncellendi");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var list = _userManager.Users.ToList();
            return Ok(list);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var selectedUser = await _userManager.FindByIdAsync(id);
            if (selectedUser == null)
            {
                return BadRequest("user bulunamadı");
            }
            await _userManager.DeleteAsync(selectedUser);
            return Ok();

        }

    }
}
