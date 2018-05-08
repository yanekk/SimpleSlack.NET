using Newtonsoft.Json;
using SimpleSlack.WebAPI.Core.Converters;
using SimpleSlack.WebAPI.Models;

namespace SimpleSlack.WebAPI.Requests.Groups
{
    internal class GroupsHistoryRequest : BaseRequest
    {
        internal override string Command => "groups.history";

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("inclusive")]
        public bool? Inclusive { get; set; }

        [JsonProperty("latest")]
        [JsonConverter(typeof(AccurateDateTimeConverter))]
        public AccurateDateTime Latest { get; set; }

        [JsonProperty("oldest")]
        [JsonConverter(typeof(AccurateDateTimeConverter))]
        public AccurateDateTime Oldest { get; set; }

        [JsonProperty("unreads")]
        public bool? Unreads { get; set; }
    }
}
