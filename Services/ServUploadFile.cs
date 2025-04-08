using Microsoft.EntityFrameworkCore;
using MSApiLoadCsvFiles.Data;
using MSApiLoadCsvFiles.Models;
using MSApiLoadCsvFiles.Repositories;
using MSApiLoadCsvFiles.Utils;

namespace MSApiLoadCsvFiles.Services
{
    public class ServUploadFile: IServUploadFile
    {
        private readonly IRepUploadFile _repUploadFile;
        private readonly AppDbContext _appDbContext;

        public ServUploadFile(IRepUploadFile repUploadFile, AppDbContext context) 
        {
            _repUploadFile = repUploadFile;
            _appDbContext = context;
        }

        public async Task<Response> LoadFiles(Request request)
        {

            Response response = new Response
            {
                code = Constants.ERR_CODE,
                message = Constants.ERR_MSG,
                user = request.user,
                dateRequest = request.date,
                dateResponse = DateTime.Now,
            };

            try
            {
                List<UploadFile> files = new List<UploadFile>();
                UploadFile file;
                var paramFilesUpload = await _appDbContext.ParamFilesUploads.ToListAsync();
                foreach (var paramFile in paramFilesUpload)
                {
                    file = new UploadFile
                    {
                        fileName = paramFile.FileName + "." + paramFile.FileType,
                        filePath = paramFile.FilePath,
                        fileType = paramFile.FileType,
                        loadStatus = false,
                        code = Constants.ERR_CODE_FILE,
                        message = Constants.ERR_MSG_FILE,
                        description = Constants.ERR_MSG_FILE
                    };
                    files.Add(file);
                }

                response.files = files;

                response = await _repUploadFile.LoadFile(response);

                if (response.code == Constants.OK_CODE)
                {
                    response.code = Constants.OK_CODE;
                    response.message = Constants.OK_MSG;
                    response.user = request.user;
                    response.dateRequest = request.date;
                    response.dateResponse = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }

            return response;
        }
    }
}
