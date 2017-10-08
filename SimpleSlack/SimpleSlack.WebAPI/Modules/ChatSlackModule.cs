using System;
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
            return PostMessage(group, new GroupMessage
            {
                Message = message
            });
        }

        public bool PostMessage(Group group, GroupMessage message)
        {
            if(message.Message == null)
                throw new ArgumentNullException("Message is required");

            var request = new ChatPostMessageRequest
            {
                Channel = group.Id,
                Text = message.Message,
                AsUser = message.AsUser,
                Attachments = message.Attachments,
                IconEmoji = message.IconEmoji,
                IconUrl = message.IconUrl,
                LinkNames = message.LinkNames,
                Parse = message.Parse,
                ReplyBroadcast = message.ReplyBroadcast,
                ThreadTs = message.ThreadTs,
                UnfurlLinks = message.UnfurlLinks,
                UnfurlMedia = message.UnfurlMedia,
                UserName = message.UserName
            };

            return Execute<ChatPostMessageResponse>(request).Ok;
        }
    }
}
