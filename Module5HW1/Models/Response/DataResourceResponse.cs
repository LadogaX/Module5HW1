using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class DataResourceResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Year { get; set; }
        public string? Color { get; set; }
        [JsonProperty("pantone_value")]
        public string? PantoneValue { get; set; }
    }
}
