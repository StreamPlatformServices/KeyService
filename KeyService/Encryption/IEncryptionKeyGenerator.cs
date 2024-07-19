namespace KeyService.Encryption
{
    public interface IEncryptionKeyGenerator
    {
        byte[] CreateEncryptionKey();
    }
}
