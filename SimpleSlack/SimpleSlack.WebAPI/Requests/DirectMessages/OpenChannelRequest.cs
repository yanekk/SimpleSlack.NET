using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Requests.DirectMessages
{
    internal class OpenChannelRequest : BaseRequest
    {
        [JsonProperty("user")]
        public string UserId { get; set; }

        [JsonProperty("return_im")]
        public bool ReturnIm = true;

        internal override string Command
        {
            get { return "im.open"; }
        }

        public OpenChannelRequest(string userId)
        {
            UserId = userId;
        }
    }
}
