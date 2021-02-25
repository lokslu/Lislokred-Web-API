using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Lislokred_Web_API
{
    public class AuthOption
    {
        public string Issuer { get; set; } // издатель токена
        public string Audience { get; set; } // потребитель токена
        public string Secret { get; set; }    // ключ для шифрации
        public int TokenLifetime { get; set; } // время жизни токена в секундах
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}