using KeyService.Models;
using KeyService.Persistance.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace KeyService.Persistance.Repositories
{
    public class KeyRepository : IKeyRepository
    {
        private readonly ILogger<KeyRepository> _logger;
        private readonly KeyDatabaseContext _keyDatabaseContext;

        private const int UNIQUE_CONSTRAINT_VIOLATION_ERROR_NUMBER = 2627;
        private const int PRIMARY_KEY_VIOLATION_ERROR_NUMBER = 2601;

        public KeyRepository(
            ILogger<KeyRepository> logger,
            KeyDatabaseContext keyDatabaseContext) 
        {
            _logger = logger;
            _keyDatabaseContext = keyDatabaseContext;
        }

        public async Task<(ResultStatus Status, KeyData Data)> GetByFileIdAsync(Guid fileId)
        {
            var keyDataResult = await _keyDatabaseContext.Keys
                .FirstOrDefaultAsync(c => c.FileId == fileId);

            if (keyDataResult == null)
            {
                _logger.LogInformation($"key for file with id: {fileId} not found!");
                return (ResultStatus.NotFound, null);
            }

            return (ResultStatus.Success, keyDataResult);
        }

        public async Task<ResultStatus> CreateAsync(KeyData keyData)
        {
            try
            {
                await _keyDatabaseContext.Keys.AddAsync(keyData);
                await _keyDatabaseContext.SaveChangesAsync();
                return ResultStatus.Success;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqliteException sqliteEx)
                {
                    if (sqliteEx.SqliteErrorCode == SQLitePCL.raw.SQLITE_CONSTRAINT)
                    {
                        _logger.LogError($"A conflict occurred while updating the database with new key: {sqliteEx.Message}");
                        return ResultStatus.Conflict;
                    }
                }
                if (ex.InnerException is SqlException sqlEx) //TODO: For SqlServer
                {
                    if (sqlEx.Number == UNIQUE_CONSTRAINT_VIOLATION_ERROR_NUMBER || sqlEx.Number == PRIMARY_KEY_VIOLATION_ERROR_NUMBER)
                    {
                        _logger.LogError($"A conflict accourd while updating the database with new key: {sqlEx.Message}");
                        return ResultStatus.Conflict;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected create new key in database error: {ex.Message}");
            }

            return ResultStatus.Failed;
        }
        
    }
}
