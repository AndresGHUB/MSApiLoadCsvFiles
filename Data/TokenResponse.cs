using Newtonsoft.Json;

namespace MSApiLoadCsvFiles.Data
{
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string access_token { get; set; }

        [JsonProperty("token_type")]
        public string token_type { get; set; }

        [JsonProperty("expires_in")]
        public int expires_in { get; set; }
    }
}
