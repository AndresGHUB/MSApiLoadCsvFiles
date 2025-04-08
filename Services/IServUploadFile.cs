using MSApiLoadCsvFiles.Models;
using System.Runtime.CompilerServices;

namespace MSApiLoadCsvFiles.Services
{
    public interface IServUploadFile
    {
        /// <summary>
        /// Load file
        /// </summary>
        /// <param name="path">path of file container</param>
        /// <param name="file">name of file to upload</param>
        /// <returns></returns>
        Task<Response> LoadFiles(Request request);
    }
}
