using System.Security.Cryptography;

namespace KeyService.Encryption
{
    public class EncryptionKeyGenerator : IEncryptionKeyGenerator
    {
        private const int KEY_SIZE = 256;
        public byte[] CreateEncryptionKey()
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = KEY_SIZE;
                aes.GenerateKey();
                return aes.Key;
            }
        }
    }
}
