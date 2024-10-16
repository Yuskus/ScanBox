using System.Security.Cryptography;

namespace ScanBoxWebApi.Utilities
{
    public class RSATool
    {
        public static RSA GetKey(string keyname)
        {
            var rsa = RSA.Create();
            rsa.ImportFromPem(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "rsa", keyname)));
            return rsa;
        }
    }
}
