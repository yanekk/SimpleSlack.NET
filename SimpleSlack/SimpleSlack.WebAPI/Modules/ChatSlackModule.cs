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

            if (message.Attachments == null || !message.Attachments.Any())
                return Execute<ChatPostMessageResponse>(request).Ok;

            request.Attachments = new List<AttachmentRequest>();
            foreach (var attachment in message.Attachments)
            {
                var attachmentRequest = new AttachmentRequest
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

                attachmentRequest.Fields = new List<AttachmentFieldRequest>();
                foreach (var field in attachment.Fields)
                {
                    attachmentRequest.Fields.Add(new AttachmentFieldRequest
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
