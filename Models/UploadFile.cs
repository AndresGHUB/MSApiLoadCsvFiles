using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MSApiLoadCsvFiles.Models
{
    public class UploadFile
    {
        public string fileName { get; set; }

        [JsonIgnore]
        public string filePath { get; set; }

        public string fileType { get; set; } = "csv";


        public bool loadStatus { get; set; }

        public string code { get; set; }

        public string message {  get; set; }

        public string description { get; set; }

        
    }
}
