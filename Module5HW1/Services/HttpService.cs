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

        public async Task<string> SendHttpAsync<TResponse>(Uri uri, HttpMethod httpMethod, HttpContent? httpContent = null)
        {
            string? contentString = null;
            var httpMessage = new HttpRequestMessage();
            httpMessage.Content = httpContent;
            httpMessage.Method = httpMethod;
            httpMessage.RequestUri = uri;

            var result = await _httpClient.SendAsync(httpMessage);

            if (result.IsSuccessStatusCode || result.StatusCode == HttpStatusCode.BadRequest)
            {
                contentString = await result.Content.ReadAsStringAsync();
                JsonConvert.DeserializeObject<TResponse>(contentString);
            }

           // Console.WriteLine($"path:{uri.OriginalString} quary:{uri.Query} Result:{result.StatusCode}");
            return contentString;
        }
    }
}