using Module5HW1.Models;
using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1
{
    public class Starter
    {
        private readonly IUserService _userService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IResourseService _resourseService;

        public Starter(
            IUserService userService,
            IAuthorizationService authorizationService,
            IResourseService resourseService)
        {
            _userService = userService;
            _authorizationService = authorizationService;
            _resourseService = resourseService;
        }

        public Task Run()
        {
            var list = new List<Task>();

            // LIST USERS
            list.Add(Task.Run(async () => await _userService.GetResponse<RootListUserResponse>("/api/users?page=2")));

            // SINGLE USER
            list.Add(Task.Run(async () => await _userService.GetResponse<RootSingleUserResponse>("/api/users/2")));

            // SINGLE USER NOT FOUND
            list.Add(Task.Run(async () => await _userService.GetResponse<RootSingleUserResponse>("/api/users/23")));

            // LIST <RESOURCE>
            list.Add(Task.Run(async () => await _resourseService.GetResponse<RootListResource>("/api/unknown")));

            // SINGLE <RESOURCE>
            list.Add(Task.Run(async () => await _resourseService.GetResponse<RootSingleResourceResponse>("/api/unknown/2")));

            // SINGLE <RESOURCE> NOT FOUND
            list.Add(Task.Run(async () => await _userService.GetResponse<RootListResource>("/api/unknown/23")));

            // CREATE
            var userMorpheus2 = new { name = "morpheus", job = "leader" };
            list.Add(Task.Run(async () => await _userService.CreateUser<CreateUserResponse>("api/users", userMorpheus2)));

            // UPDATE PUT
            var userMorpheus = new { name = "morpheus", job = "zion resident" };
            list.Add(Task.Run(async () => await _userService.UserUpDate<UpDateResponse>("api/users/2", userMorpheus, HttpMethod.Put)));

            // UPDATE PATCH
            list.Add(Task.Run(async () => await _userService.UserUpDate<UpDateResponse>("api/users/2", userMorpheus, HttpMethod.Patch)));

            // DELETE
            list.Add(Task.Run(async () => await _userService.UserDelete<UpDateResponse>("api/users/2", userMorpheus)));

            // REGISTER - SUCCESSFUL
            var requreObject = new { email = "eve.holt@reqres.in", password = "pistol" };
            list.Add(Task.Run(async () => await _authorizationService.GetResponse<IdTokenResponse>("api/register", requreObject)));

            // REGISTER - UNSUCCESSFUL
            var requreObject2 = new { email = "sydney@fife" };
            list.Add(Task.Run(async () => await _authorizationService.GetResponse<ErrorResponse>("api/register", requreObject2)));

            // LOGIN - SUCCESSFUL
            var requreObject3 = new { email = "eve.holt@reqres.in", password = "cityslicka" };
            list.Add(Task.Run(async () => await _authorizationService.GetResponse<TokenResponse>("api/login", requreObject3)));

            // LOGIN - UNSUCCESSFUL
            var requreObject4 = new { email = "sydney@fife" };
            list.Add(Task.Run(async () => await _authorizationService.GetResponse<ErrorResponse>("api/register", requreObject4)));

            // DELAYED RESPONSE
            list.Add(Task.Run(async () => await _userService.GetResponse<RootListUserResponse>("api/users?delay=3")));

            Task.WaitAll(list.ToArray());

            Console.WriteLine("Done");
            return Task.CompletedTask;
        }
    }
}