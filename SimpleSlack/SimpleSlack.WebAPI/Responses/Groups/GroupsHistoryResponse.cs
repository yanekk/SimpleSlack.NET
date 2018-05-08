using Newtonsoft.Json;
using SimpleSlack.WebAPI.Core.Converters;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Responses.Groups.Interfaces;

namespace SimpleSlack.WebAPI.Responses.Groups
{
    internal class GroupsHistoryResponse : BaseResponse, IGroupsHistoryResponse
    {
        [JsonConverter(typeof(AccurateDateTimeConverter))]
        [JsonProperty("latest")]
        public AccurateDateTime Latest { get; internal set; }

        [JsonProperty("messages")]
        public Message[] Messages { get; internal set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; internal set; }

        [JsonProperty("is_limited")]
        public bool IsLimited { get; internal set; }
    }
}
