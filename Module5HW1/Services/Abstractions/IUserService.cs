namespace Module5HW1.Services.Abstractions
{
    public interface IUserService
    {
        public Task<T> GetResponse<T>(string apiQuaryString);

        public Task<T> GetResponse<T>(string apiQuaryString, string jsonSerializableString, HttpMethod method);
        public Task<T> CreateUser<T>(string apiString, object requareObject);

        public Task<T> UserUpDate<T>(string apiString, object requareObject, HttpMethod httpMethod);

        public Task<T> UserDelete<T>(string apiString, object requareObject);
    }
}