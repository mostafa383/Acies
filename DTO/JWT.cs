using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System;
using AciesManagmentProject.Models;
using System.Security.Claims;
using System.Collections.Generic;
using System.Data;

namespace AciesManagmentProject.DTO
{
    public interface IJwt
    {
        public string CreateToken(UserTb user);
    }

    public class JWT:IJwt
    {
        private readonly IConfiguration _configuration;
        public JWT(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string CreateToken(UserTb user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var claims = new List<Claim>
            {
                new Claim("Id", user.UserId.ToString()),
                new Claim("Image", user.UserImage is  null ?"":user.UserImage),
                new Claim("Name", user.UserName ),
                new Claim("Email", user.UserEmail),
                new Claim("Phone", user.UserPhone is null ?"":user.UserPhone)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddYears(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
