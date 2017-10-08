using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Requests.Groups
{
    internal class GroupsListRequest : BaseRequest
    {
        [JsonProperty("exclude_archived")]
        public bool ExcludeArchived { get; set; }

        [JsonProperty("exclude_members")]
        public bool ExcludeMembers { get; set; }

        internal override string Command => "groups.list";
    }
}
