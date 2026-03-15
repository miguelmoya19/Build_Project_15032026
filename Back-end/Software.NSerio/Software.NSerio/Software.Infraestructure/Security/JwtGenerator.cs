using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Software.Application.Interfaces;
using Software.Domain.Entities;
using Software.Shared.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Software.Infraestructure.Security
{
    public class JwtGenerator : IJwtGenerator
    {


        private readonly JwtSettings _jwtSetting;

        public JwtGenerator(IOptions<JwtSettings> jwtGenerator)
        {
            _jwtSetting = jwtGenerator.Value;
        }

       public Task GeneratorToken(Developers user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.DeveloperId.ToString())
            };

            var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSetting.Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: _jwtSetting.Issuer,
            audience: _jwtSetting.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSetting.ExpirationMinutes),
            signingCredentials: creds);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
