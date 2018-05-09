using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Models
{
    public class DirectMessageChannel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("is_im")]
        public bool IsIm { get; set; }

        [JsonProperty("is_org_shared")]
        public bool IsOrgShared { get; set; }

        [JsonProperty("user")]
        public string UserId { get; set; }

        [JsonProperty("is_user_deleted")]
        public bool IsUserDeleted { get; set; }
    }
}
