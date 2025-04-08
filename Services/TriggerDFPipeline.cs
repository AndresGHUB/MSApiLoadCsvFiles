using Azure.Core;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using MSApiLoadCsvFiles.Data;
using MSApiLoadCsvFiles.Models;
using MSApiLoadCsvFiles.Utils;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Request = MSApiLoadCsvFiles.Models.Request;

namespace MSApiLoadCsvFiles.Services
{
    public class TriggerDFPipeline(IOptions<AzureSettings> azureSettings) : ITriggerDFPipeline
    {
        //private readonly HttpClient _httpClient = httpClient;
        private readonly AzureSettings _azureSettings = azureSettings.Value;
        //private static IConfidentialClientApplication _app;

        public async Task<ResponseDataFactory> TriggerPipilie(Request request)
        {
            ResponseDataFactory responseDataFactory = new ResponseDataFactory
            {
                code = Constants.ERR_CODE_PL,
                message = Constants.ERR_MSG_PL,
                RunId = string.Empty
            };

            // App settings
            string _token = await GetTokenMSDF(request);
            string _clientId = _azureSettings.ClientId;
            string _tenantId = _azureSettings.Tenant_id;
            string _clientSecret = _azureSettings.ClientSecret;
            string _subscriptionId = _azureSettings.SubscriptionId;
            string _resourceGroupName = _azureSettings.ResourceGroupName;
            string _dataFactoryName = _azureSettings.FactoryName;
            string _pipelineName = _azureSettings.PipelineName;
            string _resource = _azureSettings.Resource;
            string _authority = "https://login.microsoftonline.com/{0}";
            string tokenUrl = _azureSettings.ApiURLToken;
            var endpoint = $"https://management.azure.com/subscriptions/{_subscriptionId}/resourceGroups/{_resourceGroupName}/providers/Microsoft.DataFactory/factories/{_dataFactoryName}/pipelines/{_pipelineName}/createRun?api-version=2018-06-01";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                    var body = new
                    {
                        parameters = new
                        {
                            param1 = "api-version=2018-06-01",
                        }
                    };

                    var jsonBody = JsonConvert.SerializeObject(body);
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(endpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JsonConvert.DeserializeObject<PipelineResponse>(jsonResponse);
                        Console.WriteLine($"Pipeline Triggered: {jsonResponse}");
                        responseDataFactory.code = Constants.OK_CODE_PL;
                        responseDataFactory.message = Constants.OK_MSG_PL;
                        responseDataFactory.RunId = tokenResponse.RunId;
                    }
                    else
                    {
                        Console.WriteLine($"Pipeline can not trigerred: {response.StatusCode}");
                        var errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(errorContent);
                    }
                }
            }
            catch(Exception ex) 
            {
                    responseDataFactory.message = ex.Message;
            }
            return responseDataFactory;
        }

        public async Task<string> GetTokenMSDF(Request request)
        {
            // App settings
            string _clientId = _azureSettings.ClientId;
            string _tenantId = _azureSettings.Tenant_id;
            string _clientSecret = _azureSettings.ClientSecret;
            string _resource = _azureSettings.Resource;
            string _authority = "https://login.microsoftonline.com/{0}";
            string tokenUrl = _azureSettings.ApiURLToken;

            using (HttpClient client = new HttpClient())
            {
                var parameters = new Dictionary<string, string>
                {
                    { "grant_type", "client_credentials" },
                    { "client_id", _clientId },
                    { "client_secret", _clientSecret },
                    { "resource", _resource}
                };

                var content = new FormUrlEncodedContent(parameters);

                var response = await client.PostAsync(string.Format(tokenUrl, _tenantId), content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(jsonResponse);
                    return tokenResponse.access_token;
                }
                else
                {
                    Console.WriteLine($"Error get token: {response.StatusCode}");
                    return null;
                }
            }
        }

        
    }


}
