using System.Text;
using Module5HW1.Models;
using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;
        private readonly IConfigService _configService;
        private readonly string _domainName;
        public UserService(IHttpService httpService, IConfigService configService)
        {
            _httpService = httpService;
            _configService = configService;
            _domainName = _configService.Config.Domain;
        }

        public async Task<string> GetResponse<TResponse>(string apiQuaryString)
        {
            Uri uri = new (new (_domainName), apiQuaryString);
            HttpMethod method = HttpMethod.Get;

            return await _httpService.SendHttpAsync<TResponse>(uri, method);
        }

        public async Task<string> GetResponse<TResponse>(string apiQuaryString, string jsonSerializableString, HttpMethod method)
        {
            Uri uri = new (new (_domainName), apiQuaryString);
            HttpContent httpContent = new StringContent(jsonSerializableString, Encoding.UTF8, "application/json");

            return await _httpService.SendHttpAsync<TResponse>(uri, method, httpContent);
        }

        public async Task<string> CreateUser<TResponse>(string apiString, object requareObject)
        {
            var jsonObjectString = JsonConvert.SerializeObject(requareObject);
            return await GetResponse<TResponse>(apiString, jsonObjectString, HttpMethod.Post);
        }

        public async Task<string> UserUpDate<TResponse>(string apiString, object requareObject, HttpMethod httpMethod)
        {
            var jsonObjectString = JsonConvert.SerializeObject(requareObject);
            return await GetResponse<TResponse>(apiString, jsonObjectString, httpMethod);
        }

        public async Task<string> UserDelete<TResponse>(string apiString, object requareObject)
        {
            var jsonObjectString = JsonConvert.SerializeObject(requareObject);
            return await GetResponse<TResponse>(apiString, jsonObjectString, HttpMethod.Delete);
        }
    }
}
