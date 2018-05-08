using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("team_id")]
        public string TeamId { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("deleted")]
        public bool IsDeleted { get; internal set; }

        [JsonProperty("color")]
        public string Color { get; internal set; }

        [JsonProperty("real_name")]
        public string RealName { get; internal set; }

        [JsonProperty("tz")]
        public string TimeZone { get; internal set; }

        [JsonProperty("tz_label")]
        public string TimeZoneLabel { get; internal set; }

        [JsonProperty("tz_offset")]
        public int TimeZoneOffset { get; internal set; }

        [JsonProperty("profile")]
        public UserProfile Profile { get; internal set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; internal set; }

        [JsonProperty("is_owner")]
        public bool IsOwner { get; internal set; }

        [JsonProperty("is_primary_owner")]
        public bool IsPrimaryOwner { get; internal set; }

        [JsonProperty("is_restricted")]
        public bool IsRestricted { get; internal set; }

        [JsonProperty("is_ultra_restricted")]
        public bool IsUltraRestricted { get; internal set; }

        [JsonProperty("is_bot")]
        public bool IsBot { get; internal set; }

        [JsonProperty("updated")]
        public long Updated { get; internal set; }

        [JsonProperty("has_2fa")]
        public bool Has2Fa { get; internal set; }

        [JsonProperty("is_app_user")]
        public bool IsAppUser { get; internal set; }
    }
}
