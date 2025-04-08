using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MSApiLoadCsvFiles.Models
{
    public class Request
    {
        public DateTime date { get; set; }

        public string user {  get; set; }
    }
}
