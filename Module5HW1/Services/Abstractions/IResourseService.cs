namespace Module5HW1.Services.Abstractions
{
    public interface IResourseService
    {
        public Task<TResponse> GetResponse<TResponse>(string apiQuaryString);
    }
}