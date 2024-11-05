using System.Security.Cryptography;
using System.Text;

namespace ScanBoxWebApi.Utilities
{
    public class RSATool
    {
        public static RSA GetPublicKey()
        {
            var rsa = RSA.Create();
            rsa.ImportFromPem(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "rsa", "public_key.pem")));
            return rsa;
        }

        public static RSA GetPrivateKey()
        {
            var rsa = RSA.Create();
            string key64 = Environment.GetEnvironmentVariable("PRIVATE_KEY") ?? throw new Exception("Warning! Private key is not found!");
            string privateKey = Encoding.UTF8.GetString(Convert.FromBase64String(key64));
            rsa.ImportFromPem(privateKey);
            return rsa;
        }
    }
}
