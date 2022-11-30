using System.Security.Cryptography;

namespace CadastroDeEstudantes.Password
{
    public class PasswordHashAndSalt
    {
        public void CriarSenhaEmHashESalt(string senha, out byte[] senhaHash, out byte[] senhaSalt) 
        {
            using(var hmac = new HMACSHA512()) 
            {
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                senhaSalt = hmac.Key;
            }
        }

    }
}
