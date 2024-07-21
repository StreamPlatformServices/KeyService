namespace KeyService.Models
{
    public class ContentEncryptionKeyResponseModel
    {
        public Guid Uuid { get; set; }
        public Guid FileId { get; set; }

        public EncryptionKeyModel EncryptionKey { get; set; }
    }
}
