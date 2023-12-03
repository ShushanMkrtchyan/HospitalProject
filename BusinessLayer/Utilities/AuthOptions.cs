using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utilities
{
    public  class AuthOptions
    {
        public static string ISSUER { get; set; } = "MyAuthServer";
        public static string AUDIENCE { get; set; } = "http://localhost:3001/";
        public static string KEY { get; set; } = "mysupersecret_secretkey!123";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));


    }
}
