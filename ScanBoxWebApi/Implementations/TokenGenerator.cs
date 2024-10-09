﻿using DatabaseModel.DTO;
using Microsoft.IdentityModel.Tokens;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
            var key         = new RsaSecurityKey(RSATool.GetKey("private_key.pem"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature);
            var token       = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                                   _configuration["Jwt:Audience"],
                                                   claims:
                                                   [
                                                       new Claim(ClaimTypes.NameIdentifier, userDTO.Username),
                                                       new Claim(ClaimTypes.Role, userDTO.Role.ToString())
                                                   ],
                                                   expires: DateTime.Now.AddMinutes(30),
                                                   signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}