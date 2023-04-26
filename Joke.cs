using System.Text.Json.Serialization;

namespace ApiClient
{
    public class Joke
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("setup")]
        public string Setup { get; set; }
        [JsonPropertyName("punchline")]
        public string PunchLine { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }


    }
}