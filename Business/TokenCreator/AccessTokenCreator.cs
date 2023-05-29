using Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;

namespace Business.TokenCreator
{
    public class AccessTokenGenerator : IAccessTokenCreator
    {
        public IdentityDbContext<CustomUser> _context { get; set; }

        public AccessTokenGenerator(IdentityDbContext<CustomUser> context)
        {
            _context = context;
        }

        private Token GeneterateToken(IConfiguration config, CustomUser user)
        {
            DateTime expireDate = DateTime.Now.AddMinutes(1);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["Application:Secret"]);
            var authRoles = from role in _context.Roles
                            join userRole in _context.UserRoles
                                on role.Id equals userRole.RoleId
                            where userRole.UserId == user.Id
                            select new { RoleName = role.Name };
            var authClaims = new List<Claim>();
            foreach (var item in authRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, item.RoleName));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = config["Application:Audience"],
                Issuer = config["Application:Issuer"],
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                }),

                Expires = expireDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            tokenDescriptor.Subject.AddClaims(authClaims);

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            Token tokenInfo = new Token();
            tokenInfo.TokenBody = tokenString;
            tokenInfo.ExpireDate = expireDate;
            tokenInfo.RefreshToken = Guid.NewGuid().ToString();

            user.RefreshToken = tokenInfo.RefreshToken;
            user.RefreshTokenExpireDate = tokenInfo.ExpireDate.AddSeconds(30);
            _context.Users.Update(user);
            return tokenInfo;
        }

        public ApplicationUserToken GetToken(IConfiguration config, CustomUser user)
        {
            ApplicationUserToken userTokens = null;
            Token token = null;
            

            if (_context.UserTokens.Count(x => x.UserId == user.Id) > 0)
            {
                userTokens = (ApplicationUserToken) _context.UserTokens.FirstOrDefault(x => x.UserId == user.Id);

                if (userTokens.ExpireDate <= DateTime.Now)
                {
                    token = GeneterateToken(config, user);

                    userTokens.ExpireDate = token.ExpireDate;
                    userTokens.Value = token.TokenBody;

                    _context.UserTokens.Update(userTokens);
                }
            }
            else
            {
                token = GeneterateToken(config, user);

                userTokens = new ApplicationUserToken();

                userTokens.UserId = user.Id;
                userTokens.LoginProvider = "SystemAPI";
                userTokens.Name = user.UserName;
                userTokens.ExpireDate = token.ExpireDate;
                userTokens.Value = token.TokenBody;

                _context.UserTokens.Add(userTokens);
            }

            _context.SaveChanges();
            return userTokens;
        }

        public async Task<bool> DeleteToken(CustomUser user)
        {
            bool result = true;

            try
            {
                if (_context.UserTokens.Count(x => x.UserId == user.Id) > 0)
                {
                    ApplicationUserToken userTokens =
                        userTokens = (ApplicationUserToken)_context.UserTokens.FirstOrDefault(x => x.UserId == user.Id);

                    _context.UserTokens.Remove(userTokens);
                }

            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public async Task<ApplicationUserToken> GetTokenByTokenValue(string token)
        {
            var appToken = await _context.UserTokens.FirstAsync(o => o.Value == token);
            return (ApplicationUserToken)appToken;
        }

        public async Task<DateTime> GetTokenExpireDate(string refreshToken, CustomUser user)
        {
            var refToken =  (ApplicationUserToken)_context.UserTokens.FirstOrDefault(t => t.UserId == user.Id);
            var result = refToken.ExpireDate;
            return result;
        }

        public async Task<IResult> DeleteToken(string token, string refreshToken)
        {
            var selectedToken = await _context.UserTokens.FirstOrDefaultAsync(t => t.Value == token);
            _context.UserTokens.Remove(selectedToken);
            var selectedUser = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken== refreshToken);
            selectedUser.RefreshToken = null;
            selectedUser.RefreshTokenExpireDate = null;
            _context.Users.Update(selectedUser);
            return new SuccesResult();
       
        }
    }
}
