using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class RootListUserResponse
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        [JsonProperty("data")]
        public List<DataUserResponse>? DataUsers { get; set; } = new ();
        [JsonProperty("support")]
        public SupportResponse? SupportUser { get; set; }
    }
}
