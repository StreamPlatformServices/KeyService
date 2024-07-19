namespace KeyService.Models
{
    public class ContentEncryptionKeyResponseModel
    {
        public Guid Uuid { get; set; }
        public Guid FileId { get; set; }

        public byte[] Key { get; set; }
    }
}
