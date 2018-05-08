using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Requests.Common
{
    public class Attachment
    {
        [JsonProperty("fallback")]
        public string Fallback { get; internal set; }

        [JsonProperty("color")]
        public string Color { get; internal set; }

        [JsonProperty("pretext")]
        public string Pretext { get; internal set; }

        [JsonProperty("author_name")]
        public string AuthorName { get; internal set; }

        [JsonProperty("author_link")]
        public string AuthorLink { get; internal set; }

        [JsonProperty("author_icon")]
        public string AuthorIcon { get; internal set; }

        [JsonProperty("title")]
        public string Title { get; internal set; }

        [JsonProperty("title_link")]
        public string TitleLink { get; internal set; }

        [JsonProperty("text")]
        public string Text { get; internal set; }

        [JsonProperty("fields")]
        public List<AttachmentField> Fields { get; internal set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; internal set; }

        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; internal set; }

        [JsonProperty("footer")]
        public string Footer { get; internal set; }

        [JsonProperty("footer_icon")]
        public string FooterIcon { get; internal set; }

        [JsonProperty("ts")]
        public long? TimeStamp { get; internal set; }
    }
}
