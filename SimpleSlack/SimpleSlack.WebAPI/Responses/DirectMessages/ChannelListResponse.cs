using System.Collections.Generic;
using SimpleSlack.WebAPI.Models;
using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Responses.DirectMessages
{
    internal class ChannelListResponse : BaseResponse
    {
        [JsonProperty("ims")]
        public List<DirectMessageChannel> Channels;
    }
}
