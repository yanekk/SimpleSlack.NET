using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Requests.Common
{
    internal class AttachmentFieldRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("short")]
        public bool Short { get; set; }
    }
}
