
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using MSApiLoadCsvFiles.Models;
using MSApiLoadCsvFiles.Utils;
using System.Runtime;

namespace MSApiLoadCsvFiles.Services
{
    public class ServAzureBlobStorage(IOptions<AzureSettings> azureSettings) : IServAzureBlobStorage
    {
        private readonly AzureSettings _azureSettings = azureSettings.Value;

        public async Task<ResponseUpload> UploadFileToBlobAsync(string path, string name)
        {
            var _connectionStringBlob = _azureSettings.AzureStorageAccount;
            var _containerName = _azureSettings.ContainerNameStorage;
            ResponseUpload result = new ResponseUpload
            {
                Code = Constants.ERR_CODE_FILE,
                Message = Constants.ERR_MSG_FILE
            };

            try
            {
                var servClientAzureBlob = new BlobServiceClient(_connectionStringBlob);
                var servClientAzureContainer = servClientAzureBlob.GetBlobContainerClient(_containerName);
                var servStorageBlob = servClientAzureContainer.GetBlobClient(name);

                using (var file = File.OpenRead(path))
                {
                    await servStorageBlob.UploadAsync(file, overwrite: true);
                }

                result.Code = Constants.OK_CODE_FILE;
                result.Message = Constants.OK_MSG_FILE;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
