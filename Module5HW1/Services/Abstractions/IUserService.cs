namespace Module5HW1.Services.Abstractions
{
    public interface IUserService
    {
        public Task<string> GetResponse<T>(string apiQuaryString);

        public Task<string> GetResponse<TResponse>(string apiQuaryString, string jsonSerializableString, HttpMethod method);
        public Task<string> CreateUser<TResponse>(string apiString, object requareObject);

        public Task<string> UserUpDate<TResponse>(string apiString, object requareObject, HttpMethod httpMethod);

        public Task<string> UserDelete<TResponse>(string apiString, object requareObject);
    }
}