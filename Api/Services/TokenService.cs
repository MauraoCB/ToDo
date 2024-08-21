using TopDown_API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;

namespace TopDown_API.Services
{
    public class TokenService
    {

        public static string GetToken(Usuario usarioLogado)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
  
            var now = DateTime.UtcNow;
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes("h08y25p16e05r18a01t20i09v22a0102"));
            var signingCredentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256Signature);

            var header = new JwtHeader(signingCredentials);

            var payload = new JwtPayload
                                         {
                                            {"iss", "a5fgde64-e84d-485a-be51-56e293d09a69"},
                                            {"iat", now},
                                        };

            payload.AddClaims(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usarioLogado.Login),
                    new Claim(ClaimTypes.Role, usarioLogado.Funcao)
                });
                

            var secToken = new JwtSecurityToken(header, payload);

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(secToken); 
        }
    }

}

