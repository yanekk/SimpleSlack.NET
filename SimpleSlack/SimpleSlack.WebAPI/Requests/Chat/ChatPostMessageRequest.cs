using System.Collections.Generic;
using Newtonsoft.Json;
using SimpleSlack.WebAPI.Enumerations;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Requests.Common;

namespace SimpleSlack.WebAPI.Requests.Chat
{
    internal class ChatPostMessageRequest : BaseRequest
    {
        internal override string Command => "chat.postMessage";

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("as_user")]
        public bool? AsUser { get; set; }

        [JsonProperty("attachments")]
        public List<AttachmentRequest> Attachments { get; set; }

        [JsonProperty("icon_emoji")]
        public string IconEmoji { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("link_names")]
        public bool? LinkNames { get; set; }

        [JsonProperty("parse")]
        public ParseMessage Parse { get; set; }

        [JsonProperty("reply_broadcast")]
        public bool? ReplyBroadcast { get; set; }

        [JsonProperty("thread_ts")]
        public string ThreadTs { get; set; }

        [JsonProperty("unfurl_links")]
        public bool? UnfurlLinks { get; set; }

        [JsonProperty("unfurl_media")]
        public bool? UnfurlMedia { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }
    }
}
