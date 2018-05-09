using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SimpleSlack.WebAPI.Enumerations;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Requests.Chat;
using SimpleSlack.WebAPI.Requests.Common;
using SimpleSlack.WebAPI.Tests.Common;

namespace SimpleSlack.WebAPI.Tests.Chat
{
    [TestFixture]
    internal class PostMessageTests : SlackTestsBase
    {
        private string DefaultResponse = @"{
                ""ok"": true,
                ""ts"": ""1405895017.000506"",
                ""channel"": ""C024BE91L"",
                ""message"": """"
            }";

        [Test]
        public void PostSimpleGroupMessageTest()
        {
            CreateMockClient(DefaultResponse);
            WebApiClient.Chat.PostMessage(new Group {Id = "12345"}, "Test");

            var lastCommand = Connector.Commands.Last();
            lastCommand.CommandName.Should().Be("chat.postMessage");
            lastCommand.Parameters.Should().Contain(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("channel", "12345"),
                new KeyValuePair<string, string>("text", "Test")
            });
        }

        [Test]
        public void PostComplexGroupMessageTest()
        {
            CreateMockClient(DefaultResponse);
            WebApiClient.Chat.PostMessage(new Group { Id = "12345" }, new MessageParameters
            {
                Message = "this is the message",
                AsUser = false,
                Attachments = new List<AttachmentRequest> { new AttachmentRequest() },
                IconEmoji = ":chart_with_upwards_trend:",
                IconUrl = "http://lorempixel.com/48/4",
                LinkNames = false,
                Parse = ParseMessage.Full,
                ReplyBroadcast = false,
                ThreadTs = "1234",
                UnfurlLinks = false,
                UnfurlMedia = true,
                UserName = "This is me, Mark"
            });

            var lastCommand = Connector.Commands.Last();
            lastCommand.CommandName.Should().Be("chat.postMessage");
            lastCommand.Parameters.Should().Contain(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("channel", "12345"),
                new KeyValuePair<string, string>("text", "this is the message"),
                new KeyValuePair<string, string>("as_user", "false"),
                new KeyValuePair<string, string>("attachments", "[{}]"),
                new KeyValuePair<string, string>("icon_emoji", ":chart_with_upwards_trend:"),
                new KeyValuePair<string, string>("icon_url", "http://lorempixel.com/48/4"),
                new KeyValuePair<string, string>("link_names", "false"),
                new KeyValuePair<string, string>("parse", "full"),
                new KeyValuePair<string, string>("reply_broadcast", "false"),
                new KeyValuePair<string, string>("thread_ts", "1234"),
                new KeyValuePair<string, string>("unfurl_links", "false"),
                new KeyValuePair<string, string>("unfurl_media", "true"),
                new KeyValuePair<string, string>("username", "This is me, Mark"),
            });
        }

        [Test]
        public void PostGroupMessageWithAttachmentTest()
        {
            CreateMockClient(DefaultResponse);
            WebApiClient.Chat.PostMessage(new Group { Id = "12345" }, new MessageParameters
            {
                Message = "this is the message",
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

            var lastCommand = Connector.Commands.Last();
            lastCommand.CommandName.Should().Be("chat.postMessage");
            lastCommand.Parameters.Should().Contain(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("attachments", "[{\"fallback\":\"Fallback message\",\"color\":\"danger\",\"pretext\":\"Pretext\",\"author_name\":\"Bobby Tables\",\"author_link\":\"http://flickr.com/bobby/\",\"author_icon\":\"http://flickr.com/icons/bobby.jpg\",\"title\":\"Slack API Documentation\",\"title_link\":\"https://api.slack.com/\",\"text\":\"Optional text that appears within the attachment\",\"fields\":[{\"title\":\"First field\",\"value\":\"First field value\",\"short\":false},{\"title\":\"Second field\",\"value\":\"Second field value\",\"short\":true},{\"title\":\"Third field\",\"value\":\"Third field value\",\"short\":true}],\"image_url\":\"http://my-website.com/path/to/image.jpg\",\"thumb_url\":\"http://example.com/path/to/thumb.png\",\"footer\":\"Slack API\",\"footer_icon\":\"https://platform.slack-edge.com/img/default_application_icon.png\",\"ts\":946684800}]"),
            });
        }
    }
}
