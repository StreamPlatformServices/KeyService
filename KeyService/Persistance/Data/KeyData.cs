using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KeyService.Persistance.Data
{
    [Index(nameof(FileId), IsUnique = true)]
    [Index(nameof(Key), IsUnique = true)]
    public class KeyData
    {
        [Key]
        public Guid Uuid { get; set; }
        public Guid FileId { get; set; }
        public byte[] Key { get; set; }
    }
}
