namespace MSApiLoadCsvFiles.Models
{
    public class AzureSettings
    {
        public string ContainerNameStorage { get; set; } = string.Empty;
        public string AzureStorageAccount { get; set; } = string.Empty;
        public string ApiURLToken { get; set; } = string.Empty;
        public string ApiURLTrigger { get; set; } = string.Empty;
        public string Tenant_id { get; set; } = string.Empty;
        public string SubscriptionId { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string Resource { get; set; } = string.Empty;
        public string ResourceGroupName { get; set; } = string.Empty;
        public string FactoryName { get; set; } = string.Empty;
        public string PipelineName { get; set; } = string.Empty;


    }
}
