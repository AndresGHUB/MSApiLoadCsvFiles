using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSApiLoadCsvFiles.Models;
using MSApiLoadCsvFiles.Services;

namespace MSApiLoadCsvFiles.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoadCsvToBlobStorageController : ControllerBase
    {

        //private readonly ILogger<LoadCsvToBlobStorageController> _logger;
        private readonly IServUploadFile _servUploadFile;
        private readonly ITriggerDFPipeline _triggerDFPipeline;

        public LoadCsvToBlobStorageController(IServUploadFile servUploadFile, ITriggerDFPipeline triggerDFPipeline) 
        {
            _servUploadFile = servUploadFile;
            _triggerDFPipeline = triggerDFPipeline;
        } 

        /// <summary>
        /// LoadHistoricalData: Metod to load files departments, jobs and employees to Azure Blob Storage
        /// </summary>
        /// <param name="request">Object contains detail of request</param>
        /// <returns>Detail of load</returns>
        [HttpPost(Name = "LoadHistoricalData"), AllowAnonymous]
        public async Task<IActionResult> LoadHistoricalData(Request request)
        {
            var response = await _servUploadFile.LoadFiles(request);
            return Ok(response);
        }

        /// <summary>
        /// LoadHistoricalData: Metod to load files departments, jobs and employees to Azure Blob Storage
        /// </summary>
        /// <param name="request">Object contains detail of request</param>
        /// <returns>Detail of load</returns>
        [HttpPost(Name = "TriggerDFPipeline"), AllowAnonymous]
        public async Task<IActionResult> TriggerDFPipeline(Request request)
        {
            var response = await _triggerDFPipeline.TriggerPipilie(request);
            return Ok(response);
        }
    }
}
