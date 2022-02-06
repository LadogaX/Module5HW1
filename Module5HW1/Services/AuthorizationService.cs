using System.Text;
using Module5HW1.Models;
using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IHttpService _httpService;
        private readonly IConfigService _configService;
        private readonly string _domainName;
        public AuthorizationService(IHttpService httpService, IConfigService configService)
        {
            _httpService = httpService;
            _configService = configService;
            _domainName = _configService.Config.Domain;
        }

        public async Task<string> GetResponse<TResponse>(string apiQuaryString, string jsonSerializableString)
        {
            Uri uriBase = new (_domainName);
            Uri uri = new (uriBase, apiQuaryString);
            HttpMethod method = HttpMethod.Post;
            HttpContent httpContent = new StringContent(jsonSerializableString, Encoding.UTF8, "application/json");

            return await _httpService.SendHttpAsync<TResponse>(uri, method, httpContent);
        }

        public async Task<string> GetResponse<TResponse>(string apiQuaryString, object requareObject)
        {
            var jsonObjectString = JsonConvert.SerializeObject(requareObject);
            return await GetResponse<IdTokenResponse>(apiQuaryString, jsonObjectString);
        }
    }
}
