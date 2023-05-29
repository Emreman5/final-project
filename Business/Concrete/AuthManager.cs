using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.TokenCreator;
using Core.Utilities.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Concrete;
using Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILecturerService _lecturerService;
        private readonly IAccessTokenCreator _tokenCreator;

        public AuthManager(UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            RoleManager<IdentityRole> roleManager, IAccessTokenCreator accessTokenGenerator, ILecturerService lecturerService)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _tokenCreator = accessTokenGenerator;
            _lecturerService = lecturerService;
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
            if (registerDto.Role == "User")
            {
                var lecturer = new Lecturer()
                {
                    FullName = registerDto.FullName,
                    CommunicationInformation = registerDto.Email,
                    UserId = user.Id
                };
                _lecturerService.Add(lecturer);
            }
            var rr = await _userManager.CreateAsync(user, registerDto.Password);
            if (!rr.Succeeded)
            {
                return new ErrorDataResult<AuthResponseDto>(String.Join("\n", rr.ToString()));
            }
            await _userManager.AddToRoleAsync(user, registerDto.Role);

            var result = await Login(new LoginDto() { Username = registerDto.Username, Password = registerDto.Password }, config);
            return result;
        }

        public async Task<IDataResult<AuthResponseDto>> Login(LoginDto loginDto, IConfiguration config)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
            {
                return new ErrorDataResult<AuthResponseDto>(AuthMessages.CouldNotFound);
            }
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

        public async Task<IDataResult<Token>> RefreshToken(string token, IConfiguration config)
        {
           
             var user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == token);
            var accessTokenGenerator = _tokenCreator;
            var expireDate = await accessTokenGenerator.GetTokenExpireDate(token, user);
            if (expireDate < DateTime.Now && user.RefreshTokenExpireDate!.Value > DateTime.Now)
            {

                var userToken = accessTokenGenerator.GetToken(config, user);
                var result = new Token()
                {
                    TokenBody = userToken.Value,
                    ExpireDate = userToken.ExpireDate,
                    RefreshToken = user.RefreshToken,
                    RefreshTokenExpireDate = user.RefreshTokenExpireDate
                };
                return new SuccessDataResult<Token>(result);
            }
            if (user.RefreshTokenExpireDate.Value < DateTime.Now)
            {
                return new ErrorDataResult<Token>(AuthMessages.TryAgain);
            }

            return new ErrorDataResult<Token>(AuthMessages.TokenStillUsable);
        }

        public async Task<IDataResult<AuthResponseDto>> AuthMe(string token, string refreshToken, IConfiguration config)
        {
            var refreshResult = await RefreshToken(refreshToken, config);
            CustomUser user;
            IList<string> roles;
            if (!refreshResult.IsSuccess && refreshResult.Message == AuthMessages.TryAgain)
            {
                return new ErrorDataResult<AuthResponseDto>(AuthMessages.TryAgain);
            }
            var response = new AuthResponseDto();
            if (!refreshResult.IsSuccess)
            {
                user = await _userManager.Users.FirstAsync(u => u.RefreshToken == refreshToken);
                roles = await _userManager.GetRolesAsync(user);

                var tokenObj = await _tokenCreator.GetTokenByTokenValue(token);
                var oldToken = new Token()
                {
                    ExpireDate = tokenObj.ExpireDate,
                    RefreshToken = user.RefreshToken,
                    RefreshTokenExpireDate = user.RefreshTokenExpireDate,
                    TokenBody = token
                };

                response.SetUser(user, roles.ToList(), oldToken, "A");
                return new SuccessDataResult<AuthResponseDto>(response);
            }
            user = await _userManager.Users.FirstAsync(u => u.RefreshToken == refreshResult.Data.RefreshToken);
            roles = await _userManager.GetRolesAsync(user);
            response.SetUser(user, roles.ToList(), refreshResult.Data, "X");
            return new SuccessDataResult<AuthResponseDto>(response);
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
        private async Task<IResult> isExistsName(CustomUser? user)
        {
            if (user == null)
            {
                return new ErrorResult(AuthMessages.CouldNotFound);
            }
            return new SuccesResult();

        }
        private async Task<IResult> SignIn(CustomUser? user, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (result.Succeeded == false)
            {
                return new ErrorResult(AuthMessages.WrongPassword);
            }

            return new SuccesResult();
        }

        public async Task<IResult> Logout(string token, string refreshToken)
        {
            var rr = await _tokenCreator.DeleteToken(token, refreshToken);
            return new SuccesResult();
        }
    }
}
