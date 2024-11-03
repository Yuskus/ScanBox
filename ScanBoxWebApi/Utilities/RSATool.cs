using System.Security.Cryptography;

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
            rsa.ImportFromPem(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "rsa", "private_key.pem")));
            return rsa;
        }
    }
}
