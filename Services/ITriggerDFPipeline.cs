using MSApiLoadCsvFiles.Models;

namespace MSApiLoadCsvFiles.Services
{
    public interface ITriggerDFPipeline
    {
        /// <summary>
        /// Trigger the Azure Pipeline
        /// </summary>
        /// <param name="path">path of file container</param>
        /// <param name="file">name of file to upload</param>
        /// <returns></returns>
        public Task<string> GetTokenMSDF(Request request);


        /// <summary>
        /// Trigger the Azure Pipeline
        /// </summary>
        /// <param name="path">path of file container</param>
        /// <param name="file">name of file to upload</param>
        /// <returns></returns>
        public Task<ResponseDataFactory> TriggerPipilie(Request request);
    }
}
