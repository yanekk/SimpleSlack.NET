using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Models
{
    public class Topic
    {
        [JsonProperty("value")]
        public string Value { get; internal set; }
        
        [JsonProperty("creator")]
        public string Creator { get; internal set; }
        
        [JsonProperty("last_set")]
        public int LastSet { get; internal set; }
    }
}
