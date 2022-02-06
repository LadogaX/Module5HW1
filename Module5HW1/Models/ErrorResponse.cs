using Newtonsoft.Json;

namespace Module5HW1.Models
{
    public class ErrorResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}