using Newtonsoft.Json;
using SimpleSlack.WebAPI.Models;

namespace SimpleSlack.WebAPI.Responses.Users
{
    internal class UsersListResponse : BaseResponse
    {
        [JsonProperty("members")]
        public User[] Members { get; set; }
    }
}
