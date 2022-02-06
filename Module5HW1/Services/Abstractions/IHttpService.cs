namespace Module5HW1.Services.Abstractions
{
    public interface IHttpService
    {
        public Task<string> SendHttpAsync<T>(Uri uri, HttpMethod httpMethod, HttpContent httpContent = null);
    }
}