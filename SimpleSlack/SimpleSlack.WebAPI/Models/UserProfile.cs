using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Models
{
    public class UserProfile
    {
        [JsonProperty("team")]
        public string Team { get; internal set; }

        [JsonProperty("image_512")]
        public string ImageUrl512 { get; internal set; }

        [JsonProperty("image_192")]
        public string ImageUrl192 { get; internal set; }

        [JsonProperty("image_72")]
        public string ImageUrl72 { get; internal set; }

        [JsonProperty("image_48")]
        public string ImageUrl48 { get; internal set; }

        [JsonProperty("image_32")]
        public string ImageUrl32 { get; internal set; }

        [JsonProperty("image_24")]
        public string ImageUrl24 { get; internal set; }

        [JsonProperty("email")]
        public string Email { get; internal set; }

        [JsonProperty("display_name_normalized")]
        public string DisplayNameNormalized { get; internal set; }

        [JsonProperty("real_name_normalized")]
        public string RealNameNormalized { get; internal set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; internal set; }

        [JsonProperty("real_name")]
        public string RealName { get; internal set; }

        [JsonProperty("avatar_hash")]
        public string AvatarHash { get; internal set; }

        [JsonProperty("status_text")]
        public string StatusText { get; internal set; }

        [JsonProperty("status_emoji")]
        public string StatusEmoji { get; internal set; }
    }
}
