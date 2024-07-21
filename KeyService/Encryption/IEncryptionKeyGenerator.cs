using KeyService.Models;

namespace KeyService.Encryption
{
    public interface IEncryptionKeyGenerator
    {
        EncryptionKeyModel CreateEncryptionKey();
    }
}
