using AngularProjectAPI.Data;
using AngularProjectAPI.Helpers;
using AngularProjectAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AngularProjectAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly SocialContext _newsContext;

        public UserService(IOptions<AppSettings> appSettings, SocialContext newsContext)
        {
            _appSettings = appSettings.Value;
            _newsContext = newsContext;
        }

        public User Authenticate(string email, string password)
        {
            var user = _newsContext.Users.Include(r=>r.Role).Include(c=>c.Company).SingleOrDefault(x => x.Email == email && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserID", user.UserID.ToString()),
                    new Claim("Email", user.Email),
                    new Claim("RoleID", user.RoleID.ToString()),
                    new Claim("Role", user.Role.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // remove password before returning
            user.Password = null;

            return user;
        }

    }
}
