using InventoryManagementSystem.Authentication.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace InventoryManagementSystem.Authentication
{
    public class AuthIms : IAuthIms
    {
        private readonly string _key;
        public AuthIms(string key)
        {
            _key = key;
        }
        public string Authenticate(string name, string password)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(_key);
            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, name)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenhandler.CreateToken(tokenDiscriptor);
            return tokenhandler.WriteToken(token);
        }
    }
}
