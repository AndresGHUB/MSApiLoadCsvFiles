using MSApiLoadCsvFiles.Models;

namespace MSApiLoadCsvFiles.Repositories
{
    public interface IRepUploadFile
    {
        public Task<Response> LoadFile(Response response);
    }
}
