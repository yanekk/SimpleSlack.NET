using SimpleSlack.WebAPI.Connectors;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Modules.Interfaces;
using SimpleSlack.WebAPI.Requests.Chat;
using SimpleSlack.WebAPI.Responses.Chat;

namespace SimpleSlack.WebAPI.Modules
{
    internal class ChatSlackModule : SlackModule, IChatSlackModule
    {
        public ChatSlackModule(string token, ISlackConnector connector) : base(token, connector)
        {
        }

        public bool PostMessage(Group group, string message)
        {
            var result = Execute<ChatPostMessageResponse>(new ChatPostMessageRequest
            {
                Channel = group.Id,
                Text = message
            });
            return result.Ok;
        }
    }
}
