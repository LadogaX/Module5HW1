namespace Module5HW1.Services.Abstractions
{
    public interface IAuthorizationService
    {
        public Task<string> GetResponse<T>(string apiQuaryString, string jsonSerializableString);
        public Task<string> GetResponse<TResponse>(string apiQuaryString, object requareObject);
    }
}