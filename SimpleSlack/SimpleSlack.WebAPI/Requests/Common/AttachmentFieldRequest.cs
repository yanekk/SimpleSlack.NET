using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Requests.Common
{
    public class AttachmentField
    {
        [JsonProperty("title")]
        public string Title { get; internal set; }

        [JsonProperty("value")]
        public string Value { get; internal set; }

        [JsonProperty("short")]
        public bool Short { get; internal set; }
    }
}
