using Microsoft.Extensions.DependencyInjection;
using Module5HW1.Services;
using Module5HW1.Services.Abstractions;

namespace Module5HW1
{
    public class Program
    {
        public static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IHttpService, HttpService>()
            .AddTransient<IConfigService, ConfigService>()
            .AddTransient<IAuthorizationService, AuthorizationService>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<IResourseService, ResourseService>()
            .AddTransient<Starter>()
            .BuildServiceProvider();

            var start = serviceProvider.GetService<Starter>();
            await start?.Run();
        }
    }
}