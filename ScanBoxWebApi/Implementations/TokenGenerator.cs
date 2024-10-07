using DatabaseModel.DTO;
using Microsoft.IdentityModel.Tokens;
using ScanBoxWebApi.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ScanBoxWebApi.Implementations
{
    public class TokenGenerator(IConfiguration configuration) : ITokenGenerator
    {
        private readonly IConfiguration _configuration = configuration;

        public string GetToken(UserDTO userDTO)
        {
            return GenerateJwtToken(userDTO);
        }
        private string GenerateJwtToken(UserDTO userDTO)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userDTO.Username),
                new Claim(ClaimTypes.Role, userDTO.Role.ToString())
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                             _configuration["Jwt:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddHours(1),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
