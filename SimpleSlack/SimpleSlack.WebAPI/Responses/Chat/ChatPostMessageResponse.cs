using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Responses.Chat
{
    internal class ChatPostMessageResponse : BaseResponse
    {
        [JsonProperty("ts")]
        public string Ts { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }
    }
}
