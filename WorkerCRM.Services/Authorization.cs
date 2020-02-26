using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WorkerCRM.Data;
using WorkerCRM.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WorkerCRM.Common;
using WorkerCRM.Services.Dto;
namespace WorkerCRM.Services
{
    public class Authorization
    {
        private readonly PlanersDbContext _context;
        private ClaimsIdentity claimsIdentity;
        public Authorization(PlanersDbContext context)
        {
            _context = context;
            claimsIdentity = null;
        }
        public void GetIdentity(string username, string password)
        {
            User user = _context.Users.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                    {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                    };
                claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            }

        }
        public bool isCorrectUser()
        {
            return claimsIdentity != null;
        }

        public ResponceToken getToken()
        {
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            ResponceToken response = new ResponceToken();

            response.access_token = encodedJwt;
            response.username = claimsIdentity.Name;
            return response;
        }
    }
}
