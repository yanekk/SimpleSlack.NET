using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Responses
{
    internal abstract class BaseResponse
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
