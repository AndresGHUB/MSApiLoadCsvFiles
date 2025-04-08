
using MSApiLoadCsvFiles.Models;
using MSApiLoadCsvFiles.Services;
using MSApiLoadCsvFiles.Utils;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace MSApiLoadCsvFiles.Repositories
{
    public class RepUploadFile : IRepUploadFile
    {
        private readonly IServAzureBlobStorage _servAzureBlobStorage;

        public RepUploadFile(IServAzureBlobStorage servAzureBlobStorage)
        {
            _servAzureBlobStorage = servAzureBlobStorage;
        }

        public async Task<Response> LoadFile(Response response)
        {
            string code = Constants.OK_CODE;
            string message = Constants.OK_MSG;
            foreach (var file in response.files)
            {
                var index = response.files.FindIndex(n => n.fileName == file.fileName);
                try
                {
                    var fileName = response.files[index].fileName;
                    var fileNameBlob = Constants.FOLDER_STORAGE + fileName;
                    var completeFileName = response.files[index].filePath + @"\" + fileName;
                    ResponseUpload resp = new ResponseUpload() { 
                        Code = Constants.ERR_CODE_FILE, 
                        Message = Constants.ERR_MSG_FILE 
                    };

                    resp = await _servAzureBlobStorage.UploadFileToBlobAsync(completeFileName, fileNameBlob);
                    if (resp != null)
                    {
                        if (resp.Code == Constants.OK_CODE_FILE)
                        {
                            response.files[index].loadStatus = true;
                            response.files[index].code = Constants.OK_CODE_FILE;
                            response.files[index].message = Constants.OK_MSG_FILE;
                            response.files[index].description = Constants.OK_DESC_FILE;
                        }
                        else
                        {
                            response.files[index].message = resp.Message;
                        }
                    }
                }
                catch (Exception ex) 
                {
                    throw new Exception(ex.Message);
                    code = Constants.ERR_CODE;
                    message = Constants.ERR_MSG;
                    response.files[index].description = ex.Message;
                }
                response.code = code;
                response.message = message; 
            }
            return response;
        }
    }
}
