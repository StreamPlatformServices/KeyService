using KeyService.Models;
using KeyService.Persistance.Data;

namespace KeyService.DataMappers
{
    public static class KeyDataMapper
    {
        public static KeyData ToKeyData(this ContentEncryptionKeyRequestModel model)
        {
            return new KeyData
            {
                Uuid = Guid.NewGuid(),
                FileId = model.FileId,
                Key = [0x64,0xAB, 0x44, 0x54, 0x64, 0xAB, 0x44, 0x54], //TODO: NOW!!!!!!!!! Create modeule for creating secure AES symetric keys !!!!!!!!
            };
        }
        
        public static ContentEncryptionKeyResponseModel ToKeyResponseModel(this KeyData data)
        {
            return new ContentEncryptionKeyResponseModel
            {
                Uuid = data.Uuid,
                FileId = data.FileId,
                Key = data.Key
            };
        }
    }

}
