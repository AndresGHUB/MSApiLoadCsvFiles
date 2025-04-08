using Newtonsoft.Json;

namespace MSApiLoadCsvFiles.Data
{
    public class PipelineResponse
    {
        [JsonProperty("runId")]
        public string RunId { get; set; } = string.Empty;
    }
}
