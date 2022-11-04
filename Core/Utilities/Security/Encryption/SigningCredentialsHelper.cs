using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) // JSON web token servislerinin oluşturulabilimesi için(kullanıcı adı parola falan credentialdır,anahtar) elimizeki securitykey'i vereceğiz ve o da imzalama nesnesini bize döndürecek.
        {// JSON web tokeninin yöneteceksin, senin güvenlik algoritman ve keyin bunlardır der web api'ye
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
