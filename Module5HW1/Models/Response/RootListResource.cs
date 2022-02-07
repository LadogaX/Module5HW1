using Newtonsoft.Json;

namespace Module5HW1.Models
{
    internal class RootListResource
    {
            [JsonProperty("page")]
            public int Page { get; set; }

            [JsonProperty("per_page")]
            public int PerPage { get; set; }

            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("total_pages")]
            public int TotalPages { get; set; }

            [JsonProperty("data")]
            public List<DataResourceResponse>? DataResources { get; set; }

            [JsonProperty("support")]
            public SupportResponse? Support { get; set; }
    }
}
