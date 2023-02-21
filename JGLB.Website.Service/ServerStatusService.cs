using JGLB.Common;
using JGLB.Website.Data;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Json;

namespace JGLB.Website.Service
{
    [Service]
    public class ServerStatusService
    {
        private readonly IHttpClientFactory _HttpClientFactory = null!;
        private readonly ILogger<ServerStatusService> _Logger = null!;
        public ServerStatusService(IHttpClientFactory httpClientFactory, ILogger<ServerStatusService> logger) 
        {
            _HttpClientFactory = httpClientFactory;
            _Logger = logger;
        }
        public async Task<ServerStatsResponse?> GetServerStats() 
        {
            using HttpClient client = _HttpClientFactory.CreateClient();
            try
            {
                ServerStatsResponse response = await client.GetFromJsonAsync<ServerStatsResponse>("http://91.216.169.17/json/stats.json");
                return response;
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "GetServerStats");
            }
            return null;
        }
    }
}