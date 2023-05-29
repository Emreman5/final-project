using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _config;
        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _config = configuration;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {     
            try
            {
                var result = await _authService.CreateUser(dto, _config);
                if (!result.IsSuccess)
                {
                    return StatusCode(403, result.Message);
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }



        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.Login(dto, _config);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet("AuthMe")]
        public async Task<IActionResult> Authme([FromHeader] string token, [FromHeader] string refreshToken)
        {
            var result = await _authService.AuthMe(token, refreshToken, _config);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromHeader] string token, [FromHeader] string refreshToken)
        {
            var result = await _authService.Logout(token, refreshToken);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
