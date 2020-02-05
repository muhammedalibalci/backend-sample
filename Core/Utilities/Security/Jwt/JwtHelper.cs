using Core.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        IConfiguration Configuration;
        TokenOptions tokenOptions;
        DateTime tokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            tokenExpiration = DateTime.Now.AddMinutes(Convert.ToDouble(tokenOptions.AccessTokenExpiration));
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwt = CreateJwtSecurityToken(tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = tokenExpiration
            };

        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: tokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            var roles = operationClaims.Select(c => c.Name).ToArray();
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
            return claims;
        }
    }
}
