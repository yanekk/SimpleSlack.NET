using Newtonsoft.Json;
using SimpleSlack.WebAPI.Models;

namespace SimpleSlack.WebAPI.Responses.DirectMessages
{
    internal class OpenChannelResponse : BaseResponse
    {
        [JsonProperty("channel")]
        public DirectMessageChannel Channel { get; set; }
    }
}
