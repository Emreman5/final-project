using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Business.TokenCreator
{
    public interface IAccessTokenCreator
    {
        public ApplicationUserToken GetToken(IConfiguration config, CustomUser user);
        public Task<bool> DeleteToken(CustomUser user);
        public Task<ApplicationUserToken> GetTokenByTokenValue(string token);
    }
}
