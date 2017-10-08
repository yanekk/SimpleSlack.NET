using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Models
{
    public class Group
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("created")]
        public int Created { get; internal set; }

        [JsonProperty("creator")]
        public string Creator { get; internal set; }

        [JsonProperty("is_archived")]
        public bool IsArchived { get; internal set; }

        [JsonProperty("members")]
        public string[] Members { get; internal set; }

        [JsonProperty("topic")]
        public Topic Topic { get; internal set; }

        [JsonProperty("purpose")]
        public Purpose Purpose { get; internal set; }
    }
}
