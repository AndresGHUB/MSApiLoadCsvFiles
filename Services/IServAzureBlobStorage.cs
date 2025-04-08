using MSApiLoadCsvFiles.Models;

namespace MSApiLoadCsvFiles.Services
{
    public interface IServAzureBlobStorage
    {
        Task<ResponseUpload> UploadFileToBlobAsync(string path, string name);
    }
}
