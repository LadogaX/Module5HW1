using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class RootSingleResourceResponse
    {
        [JsonProperty("data")]
        public DataResourceResponse? DataResource { get; set; }
        [JsonProperty("support")]
        public SupportResponse? Support { get; set; }
    }
}
