
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
    }
}
//Usage Example
//string sSignature = Signature.GenerateSHA256("1234567ABCDEFGHIJ"); 
//{
//}
