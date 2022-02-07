namespace Module5HW1.Services.Abstractions
{
    public interface IHttpService
    {
        public Task<T?> SendHttpAsync<T>(Uri uri, HttpMethod httpMethod, object? httpContent = null);
    }
}