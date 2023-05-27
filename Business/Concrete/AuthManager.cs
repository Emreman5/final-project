using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.TokenCreator;
using Core.Utilities.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Concrete;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccessTokenCreator _tokenCreator;

        public AuthManager(UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            RoleManager<IdentityRole> roleManager, IAccessTokenCreator accessTokenGenerator)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _tokenCreator = accessTokenGenerator;
        }
        public async Task<IDataResult<AuthResponseDto>> CreateUser(RegisterDto registerDto, IConfiguration config)
        {
            var logic = BusinessRules.Run(await UserExistsName(registerDto.Username));
            if (logic.IsSuccess == false)
                return await Task.FromResult(new ErrorDataResult<AuthResponseDto>(logic.Message));
            var user = new CustomUser()
            {
                Fullname = registerDto.FullName,
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };
            var rr = await _userManager.CreateAsync(user, registerDto.Password);
            if (!rr.Succeeded)
            {
                Console.WriteLine(rr.ToString());
                return new ErrorDataResult<AuthResponseDto>(String.Join("\n", rr.ToString()));
            }
            await _userManager.AddToRoleAsync(user, registerDto.Role);

            var result = await Login(new LoginDto() { Username = registerDto.Username, Password = registerDto.Password }, config);
            return result;
        }

        public async Task<IDataResult<AuthResponseDto>> Login(LoginDto loginDto, IConfiguration config)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            Console.WriteLine(user.Fullname);
            var logic = BusinessRules.Run(await SignIn(user, loginDto.Password));
            if (logic.IsSuccess == false)
                return new ErrorDataResult<AuthResponseDto>(logic.Message);
            ApplicationUserToken userTokens = _tokenCreator.GetToken(config, user);
            var roles = await _userManager.GetRolesAsync(user);
            var token = new Token()
            {
                TokenBody = userTokens.Value,
                ExpireDate = userTokens.ExpireDate,
                RefreshToken = user.RefreshToken,
                RefreshTokenExpireDate = user.RefreshTokenExpireDate
            };
            var result = new AuthResponseDto()
            {
                Email = user.Email,
                Roles = roles.ToList(),
                Token = token,
                UserId = user.Id,
                Status = true
            };
            return new SuccessDataResult<AuthResponseDto>(result);
        }

        public Task<IDataResult<Token>> RefreshToken(string token, IConfiguration config)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<AuthResponseDto>> AuthMe(string token, string refreshToken, IConfiguration config)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<AuthResponseDto>> RegisterAdminUser(RegisterDto registerDto, IConfiguration config)
        {
            throw new NotImplementedException();
        }
        private async Task<IResult> UserExistsName(string userName)
        {
            if (await _userManager.FindByNameAsync(userName) != null)
            {
                return new ErrorResult("böyle bir kullanıcı var");
            }
            return new SuccesResult();
        }
        private async Task<IResult> SignIn(CustomUser user, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (result.Succeeded == false)
            {
                return new ErrorResult();
            }

            return new SuccesResult();
        }
    }
}
