using KeyService.DataMappers;
using KeyService.Models;
using KeyService.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KeyService.Controllers
{
    [ApiController]
    [Route("key")]
    public class KeyController : ControllerBase
    {
        private readonly ILogger<KeyController> _logger;
        private readonly IKeyRepository _keyRepository;
        public KeyController(
            ILogger<KeyController> logger,
            IKeyRepository keyRepository)
        {
            _logger = logger;
            _keyRepository = keyRepository;
        }
       
        [HttpGet("{fileId}")]
        public async Task<IActionResult> GetkeyByfileIdAsync(Guid fileId)
        {
            _logger.LogInformation("Start get key by file id procedure.");

            var result = await _keyRepository.GetByFileIdAsync(fileId);

            if (result.Status == ResultStatus.NotFound)
            {
                return NotFound();
            }

            if (result.Data == null || result.Status == ResultStatus.Failed)
            {
                _logger.LogError("An unexpected error occurred while getting key.");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            _logger.LogInformation("Finished successfully get key by file id procedure.");
           return Ok(result.Data.ToKeyResponseModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddkeyAsync(ContentEncryptionKeyRequestModel keyRequestModel)
        {
            _logger.LogInformation($"Start add new key procedure for file: {keyRequestModel.FileId}.");

            var result = await _keyRepository.CreateAsync(keyRequestModel.ToKeyData());

            if (result == ResultStatus.Conflict)
            {
                return Conflict();
            }

            if (result == ResultStatus.Failed)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            _logger.LogInformation($"Finished successfully add new key procedure for file: {keyRequestModel.FileId}."); //TODO: Log id in the rest of endpoints??
            return Ok();
        }
    }
}
