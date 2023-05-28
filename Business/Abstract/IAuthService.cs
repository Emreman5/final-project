
using Core.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.DTOs;
using Microsoft.Extensions.Configuration;

namespace Business.Abstract
{
    public interface IAuthService
    {
        public Task<IDataResult<AuthResponseDto>> CreateUser(RegisterDto registerDto, IConfiguration config);
        public Task<IDataResult<AuthResponseDto>> Login(LoginDto loginDto, IConfiguration config);
        public Task<IDataResult<Token>> RefreshToken(string token, IConfiguration config);
        public Task<IDataResult<AuthResponseDto>> AuthMe(string token, string refreshToken, IConfiguration config);
        public Task<IDataResult<AuthResponseDto>> RegisterAdminUser(RegisterDto registerDto, IConfiguration config);
        public Task<IResult> Logout(string token, string refreshToken);

    }
}
