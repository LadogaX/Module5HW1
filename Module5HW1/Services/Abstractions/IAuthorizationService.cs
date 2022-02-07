namespace Module5HW1.Services.Abstractions
{
    public interface IAuthorizationService
    {
        public Task<T> GetResponse<T>(string apiQuaryString, string jsonSerializableString);
        public Task<T> GetResponse<T>(string apiQuaryString, object requareObject);
    }
}