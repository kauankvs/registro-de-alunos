using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CadastroDeEstudantes.Service
{
    public class TokenService
    {
        public string GerarToken(string email) 
        {
            byte[] chave = Encoding.ASCII.GetBytes(Settings.Secret);
            var gerenciadorToken = new JwtSecurityTokenHandler();
            var relatorToken = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature),
            };
            SecurityToken token = gerenciadorToken.CreateToken(relatorToken);
            return gerenciadorToken.WriteToken(token);
        }
    }
}
