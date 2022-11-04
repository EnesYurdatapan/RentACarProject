using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
   public class SecurityKeyHelper// şifreleme olan sistemlerde bizim her şeyi byte array formatında oluşturmamız gerekiyor.Basit stringle olmaz.ASP.NET'in json web servicelerinin anlayacağı şekilde yazmamız lazım
    {// key'i byte array haline getiriyoruz
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
