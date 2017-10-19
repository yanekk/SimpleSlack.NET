using System;
using System.Collections.Generic;
using System.Linq;
using SimpleSlack.WebAPI.Core.Connectors;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Modules.Interfaces;
using SimpleSlack.WebAPI.Requests.Chat;
using SimpleSlack.WebAPI.Requests.Common;
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
            return PostMessage(group, new GroupMessageParameters
            {
                Message = message
            });
        }

        public bool PostMessage(Group group, GroupMessageParameters messageParameters)
        {
            if(messageParameters.Message == null)
                throw new ArgumentNullException("Message is required");

            var request = new ChatPostMessageRequest
            {
                Channel = group.Id,
                Text = messageParameters.Message,
                AsUser = messageParameters.AsUser,
                IconEmoji = messageParameters.IconEmoji,
                IconUrl = messageParameters.IconUrl,
                LinkNames = messageParameters.LinkNames,
                Parse = messageParameters.Parse,
                ReplyBroadcast = messageParameters.ReplyBroadcast,
                ThreadTs = messageParameters.ThreadTs,
                UnfurlLinks = messageParameters.UnfurlLinks,
                UnfurlMedia = messageParameters.UnfurlMedia,
                UserName = messageParameters.UserName
            };

            if (messageParameters.Attachments == null || !messageParameters.Attachments.Any())
                return Execute<ChatPostMessageResponse>(request).Ok;

            request.Attachments = new List<Attachment>();
            foreach (var attachment in messageParameters.Attachments)
            {
                var attachmentRequest = new Attachment
                {
                    Fallback = attachment.Fallback,
                    Color = attachment.Color?.Value,
                    Pretext = attachment.Pretext,
                    AuthorName = attachment.AuthorName,
                    AuthorLink = attachment.AuthorLink,
                    AuthorIcon = attachment.AuthorIcon,
                    Title = attachment.Title,
                    TitleLink = attachment.TitleLink,
                    Text = attachment.Text,
                    ImageUrl = attachment.ImageUrl,
                    ThumbUrl = attachment.ThumbUrl,
                    Footer = attachment.Footer,
                    FooterIcon = attachment.FooterIcon,
                    TimeStamp = CalculateTimestamp(attachment.TimeStamp)
                };
                request.Attachments.Add(attachmentRequest);
                if (attachment.Fields == null || !attachment.Fields.Any())
                    continue;

                attachmentRequest.Fields = new List<AttachmentField>();
                foreach (var field in attachment.Fields)
                {
                    attachmentRequest.Fields.Add(new AttachmentField
                    {
                        Title = field.Title,
                        Value = field.Value,
                        Short = field.IsShort
                    });
                }
            }

            return Execute<ChatPostMessageResponse>(request).Ok;
        }

        private long? CalculateTimestamp(DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
                return null;

            return (long) (dateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
    }
}
