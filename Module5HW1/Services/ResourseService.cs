using System.Text;
using Module5HW1.Models;
using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1.Services
{
    public class ResourseService : IResourseService
    {
        private readonly IHttpService _httpService;
        private readonly IConfigService _configService;
        private readonly string _domainName;
        public ResourseService(IHttpService httpService, IConfigService configService)
        {
            _httpService = httpService;
            _configService = configService;
            _domainName = _configService.Config.Domain;
        }

        public async Task<TResponse> GetResponse<TResponse>(string apiQuaryString)
        {
            Uri uri = new (new (_domainName), apiQuaryString);
            HttpMethod method = HttpMethod.Get;

            return await _httpService.SendHttpAsync<TResponse>(uri, method);
        }
    }
}
