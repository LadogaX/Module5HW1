using System.Net;
using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient? _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient() !;
        }

        public async Task<TResponse?> SendHttpAsync<TResponse>(Uri uri, HttpMethod httpMethod, object? httpContent = null)
        {
            string? contentString = null;

            var httpMessage = new HttpRequestMessage();
            httpMessage.Content = httpContent is HttpContent ? (HttpContent)httpContent : null;
            httpMessage.Method = httpMethod;
            httpMessage.RequestUri = uri;

            var result = await _httpClient.SendAsync(httpMessage);

            if (result.IsSuccessStatusCode || result.StatusCode == HttpStatusCode.BadRequest)
            {
                contentString = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(contentString);
            }

            return default;
        }
    }
}