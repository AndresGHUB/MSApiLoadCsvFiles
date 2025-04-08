using System.ComponentModel.DataAnnotations;

namespace MSApiLoadCsvFiles.Models
{
    public class ResponseDataFactory
    {
        public string code { get; set; }

        public string message { get; set; }

        public string RunId {  get; set; }
    }
}
