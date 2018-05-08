using SimpleSlack.WebAPI.Models;

namespace SimpleSlack.WebAPI.Requests.Groups
{
    public class GroupHistoryParameters
    {
        public int? Count { get; set; }
        public bool? Inclusive { get; set; }
        public AccurateDateTime Latest { get; set; }
        public AccurateDateTime Oldest { get; set; }
        public bool? Unreads { get; set; }
    }
}
