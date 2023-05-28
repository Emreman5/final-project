using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Core.Utilities.Abstract;

namespace Business.TokenCreator
{
    public interface IAccessTokenCreator
    {
        public ApplicationUserToken GetToken(IConfiguration config, CustomUser user);
        public Task<bool> DeleteToken(CustomUser user);
        public Task<ApplicationUserToken> GetTokenByTokenValue(string token);
        public Task<DateTime> GetTokenExpireDate(string refreshToken, CustomUser user);
        public Task<IResult> DeleteToken(string token, string refreshToken);

    }
}
