using System.Collections.Generic;
using Newtonsoft.Json;
using SimpleSlack.WebAPI.Core.Converters;
using SimpleSlack.WebAPI.Requests.Common;

namespace SimpleSlack.WebAPI.Models
{
    public class Message
    {
        [JsonProperty("type")]
        public string Type { get; internal set; }

        [JsonProperty("ts")]
        [JsonConverter(typeof(AccurateDateTimeConverter))]
        public AccurateDateTime TimeSpan { get; internal set; }

        [JsonProperty("user")]
        public string UserId { get; internal set; }

        [JsonProperty("text")]
        public string Text { get; internal set; }

        [JsonProperty("is_starred")]
        public bool IsStarred { get; internal set; }

        [JsonProperty("sub_type")]
        public string SubType { get; internal set; }

        [JsonProperty("bot_id")]
        public string BotId { get; internal set; }

        [JsonProperty("username")]
        public string Username { get; internal set; }

        [JsonProperty("attachments")]
        public AttachmentRequest[] Attachments { get; internal set; }

        [JsonProperty("icons")]
        public Dictionary<string, string> Icons { get; internal set; }
    }
}
