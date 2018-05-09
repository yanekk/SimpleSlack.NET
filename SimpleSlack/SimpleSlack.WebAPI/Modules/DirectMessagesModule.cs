using System.Collections.Generic;
using SimpleSlack.WebAPI.Core.Connectors;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Modules.Interfaces;
using SimpleSlack.WebAPI.Requests.DirectMessages;
using SimpleSlack.WebAPI.Responses.DirectMessages;

namespace SimpleSlack.WebAPI.Modules
{
    internal class DirectMessagesModule : SlackModule, IDirectMessagesModule
    {
        public DirectMessagesModule(string token, ISlackConnector connector) : base(token, connector)
        {
        }

        public IList<DirectMessageChannel> Channels()
        {
            return Execute<ChannelListResponse>(new ChannelListRequest()).Channels;
        }

        public DirectMessageChannel OpenChannel(User user)
        {
            return Execute<OpenChannelResponse>(new OpenChannelRequest(user.Id)).Channel;
        }
    }
}
