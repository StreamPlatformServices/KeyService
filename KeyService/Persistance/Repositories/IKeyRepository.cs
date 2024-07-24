using KeyService.Persistance.Data;
using KeyService.Models;

namespace KeyService.Persistance.Repositories
{
    public interface IKeyRepository
    {
        Task<(ResultStatus Status, KeyData Data)> GetByFileIdAsync(Guid fileId);
        Task<ResultStatus> CreateAsync(KeyData keyData);
        Task<ResultStatus> DeleteAsync(Guid fileId);

        //Task<ResultStatus> UpdateAsync(Guid uuid, KeyData licenseData);
        //Task<ResultStatus> DeleteAsync(Guid uuid);
    }
}
