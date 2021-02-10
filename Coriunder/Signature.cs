
using System;
using System.Text;

namespace Coriunder
{ 
    public class Signature
    {
        public static string GenerateSHA256(string value)
        {
            System.Security.Cryptography.SHA256 sh = System.Security.Cryptography.SHA256.Create();
            byte[] hashValue = sh.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
            return System.Convert.ToBase64String(hashValue);
        }

        public static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
    }
}
   
