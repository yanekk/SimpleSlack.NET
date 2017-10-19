using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SimpleSlack.WebAPI.Enumerations;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Requests.Chat;
using SimpleSlack.WebAPI.Requests.Common;

namespace SimpleSlack.WebAPI.Samples
{
    [TestFixture]
    public class Groups
    {
        [Test]
        public void PostMessageOnGroup()
        {
            // initialize client with app token
            var client = new SlackWebApiClient("## api-token ##");

            // get group list
            var groups = client.Groups.List();

            // find specific group
            var myGroup = groups.Single(g => g.Name == "my-group");

            // post a message
            client.Chat.PostMessage(myGroup, "This is the message from bot.");
        }

        [Test]
        public void PostMessageOnGroupWithParameters()
        {
            var client = new SlackWebApiClient("## api-token ##");
            var groups = client.Groups.List();
            var myGroup = groups.Single(g => g.Name == "my-group");

            // post a message with various parameters
            client.Chat.PostMessage(myGroup, new GroupMessageParameters
            {
                Message = "this is the message",
                AsUser = false,
                IconEmoji = ":chart_with_upwards_trend:",
                IconUrl = "http://lorempixel.com/48/4",
                LinkNames = false,
                Parse = ParseMessage.Full,
                ReplyBroadcast = false,
                ThreadTs = "1234",
                UnfurlLinks = false,
                UnfurlMedia = true,
                UserName = "Tom Hanks"
            });
        }

        [Test]
        public void PostMessageOnGroupWithAttachment()
        {
            var client = new SlackWebApiClient("## api-token ##");
            var groups = client.Groups.List();
            var myGroup = groups.Single(g => g.Name == "my-group");

            // post a message with attachment
            client.Chat.PostMessage(myGroup, new GroupMessageParameters
            {
                Message = "this is the message",
                AsUser = false,
                Attachments = new List<AttachmentRequest> {
                    new AttachmentRequest {
                        Fallback = "Fallback message",
                        Color = Colour.Danger,
                        Pretext = "Pretext",
                        AuthorName = "Bobby Tables",
                        AuthorLink = "http://flickr.com/bobby/",
                        AuthorIcon = "http://flickr.com/icons/bobby.jpg",
                        Title = "Slack API Documentation",
                        TitleLink = "https://api.slack.com/",
                        Text = "Optional text that appears within the attachment",
                        Fields = new List<AttachmentFieldRequest>
                            {
                                new AttachmentFieldRequest("First field", "First field value"),
                                new AttachmentFieldRequest("Second field", "Second field value", true),
                                new AttachmentFieldRequest("Third field", "Third field value", true)
                            },
                        ImageUrl = "http://my-website.com/path/to/image.jpg",
                        ThumbUrl = "http://example.com/path/to/thumb.png",
                        Footer = "Slack API",
                        FooterIcon = "https://platform.slack-edge.com/img/default_application_icon.png",
                        TimeStamp = new DateTime(2000, 01, 01)
                    }
                }
            });
        }

        [Test]
        public void GetGroupHistory()
        {
            var client = new SlackWebApiClient("## api-token ##");
            var groups = client.Groups.List();
            var myGroup = groups.Single(g => g.Name == "my-group");

            // get history 
            var history = client.Groups.History(myGroup);
        }
    }
}
