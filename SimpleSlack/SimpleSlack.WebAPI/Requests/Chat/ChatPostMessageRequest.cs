using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Requests.Chat
{
    internal class ChatPostMessageRequest : BaseRequest
    {
        internal override string Command => "chat.postMessage";

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

    }
}
