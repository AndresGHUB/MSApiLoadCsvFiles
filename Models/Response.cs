using System.ComponentModel.DataAnnotations;

namespace MSApiLoadCsvFiles.Models
{
    public class Response
    {
        public string code { get; set; }

        public string message { get; set; }

        public string user {  get; set; }

        public DateTime dateRequest { get; set; }

        public DateTime dateResponse { get; set; }

        public List<UploadFile> files { get; set; }
    }
}
