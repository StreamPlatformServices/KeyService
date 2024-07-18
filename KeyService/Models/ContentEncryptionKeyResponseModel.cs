namespace KeyService.Models
{
    public class ContentEncryptionKeyResponseModel
    {
        public Guid Uuid { get; set; }
        public Guid FileId { get; set; }

        //TODO: what type!!!???
        public byte[] Key { get; set; }
    }
}
