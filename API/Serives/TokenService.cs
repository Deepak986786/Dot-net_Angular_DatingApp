using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Serives
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config) { 
          _config = config;
        }
        public string CreateToken(AppUser user)
        {
            var tokenKey = this._config["TokenKey"];
            if(tokenKey.Length < 64)
                throw new Exception("Token key must be at least 64 characters long");

            // Token creation logic goes here
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenKey));

            var claims = new List<Claim> { 
                new (ClaimTypes.Email , user.Email),
                new ("ID", user.Id.ToString())
            };

            var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
