namespace SimpleSlack.WebAPI.Requests.DirectMessages
{
    internal class ChannelListRequest : BaseRequest
    {
        internal override string Command
        {
            get { return "im.list"; }
        }
    }
}
