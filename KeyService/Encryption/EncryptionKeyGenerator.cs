using KeyService.Models;
using System.Security.Cryptography;

namespace KeyService.Encryption
{
    public class EncryptionKeyGenerator : IEncryptionKeyGenerator //TODO: Entity
    {
        private const int KEY_SIZE = 256;
        public EncryptionKeyModel CreateEncryptionKey()
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = KEY_SIZE;
                aes.GenerateKey();
                aes.GenerateIV();

                return new EncryptionKeyModel { Key = aes.Key, IV = aes.IV };
            }
        }
    }
}
