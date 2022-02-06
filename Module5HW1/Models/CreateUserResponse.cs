using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class CreateUserResponse
    {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("job")]
            public string Job { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }
    }
}
