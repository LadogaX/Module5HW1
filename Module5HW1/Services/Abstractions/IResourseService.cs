namespace Module5HW1.Services.Abstractions
{
    public interface IResourseService
    {
        public Task<string> GetResponse<TResponse>(string apiQuaryString);
    }
}