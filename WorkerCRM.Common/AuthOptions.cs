using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WorkerCRM.Common
{
    public class AuthOptions
    {
        public const string ISSUER = "NightDev Production"; // издатель токена
        public const string AUDIENCE = "BlackList CRM"; // потребитель токена
        const string KEY = "mysupersecret_BlackList!123";   // ключ для шифрации
        public const int LIFETIME = 1440; // время жизни токена - 24 часа
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
