using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class RootSingleUserResponse
    {
        [JsonProperty("data")]
        public DataUserResponse? DataUsers { get; set; }
        [JsonProperty("support")]
        public SupportResponse? SupportUser { get; set; }
    }
}
