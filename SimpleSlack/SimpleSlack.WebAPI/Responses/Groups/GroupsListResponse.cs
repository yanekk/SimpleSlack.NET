using Newtonsoft.Json;
using SimpleSlack.WebAPI.Models;

namespace SimpleSlack.WebAPI.Responses.Groups
{
    internal class GroupsListResponse : BaseResponse
    {
        [JsonProperty("groups")]
        public Group[] Groups { get; set; }
    }
}
