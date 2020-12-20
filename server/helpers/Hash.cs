using System.Text;
using System;
using System.Security.Cryptography;

namespace App.Helpers 
{
    public static class Hash 
    {
        public static string Make(string value)
        {
            UTF8Encoding utf8 = new UTF8Encoding();

            var md5 = new MD5CryptoServiceProvider();
            
            var byteHash = md5.ComputeHash(
                utf8.GetBytes(value)
            );

            var hashedPassword = Convert.ToBase64String(byteHash);

            return hashedPassword;
        }
    }
}