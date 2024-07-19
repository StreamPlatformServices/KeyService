﻿using KeyService.Models;
using KeyService.Persistance.Data;

namespace KeyService.DataMappers
{
    public static class KeyDataMapper
    {
        public static KeyData ToKeyData(this ContentEncryptionKeyRequestModel model, byte[] key)
        {
            return new KeyData
            {
                Uuid = Guid.NewGuid(),
                FileId = model.FileId,
                Key = key
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
