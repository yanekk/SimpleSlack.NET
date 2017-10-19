using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Requests.Groups;
using SimpleSlack.WebAPI.Tests.Common;

namespace SimpleSlack.WebAPI.Tests.Groups
{
    [TestFixture]
    internal class GroupsHistoryTests : SlackTestsBase
    {
        [Test]
        public void GroupHistoryWithoutParameters()
        {
            CreateMockClient(@"{
                ""ok"": true,
                ""latest"": ""1358547726.000003"",
                ""messages"": [
                    {
                        ""type"": ""message"",
                        ""ts"": ""1358546515.000008"",
                        ""user"": ""U2147483896"",
                        ""text"": ""Hello""
                    },
                    {
                        ""type"": ""message"",
                        ""ts"": ""1358546515.000007"",
                        ""user"": ""U2147483896"",
                        ""text"": ""World"",
                        ""is_starred"": true,
                    },
                    {
                        ""type"": ""something_else"",
                        ""ts"": ""1358546515.000007"",
                        ""wibblr"": true
                    }
                ],
                ""has_more"": false
            }");
            var groupHistory = WebApiClient.Groups.History(new Group {Id = "G12345"});

            var lastCommand = Connector.Commands.Last();
            lastCommand.CommandName.Should().Be("groups.history");
            lastCommand.Parameters.Should().Contain(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("channel", "G12345")
            });

            groupHistory.HasMore.Should().BeFalse();
            groupHistory.Latest.Should().Be(new AccurateDateTime(new DateTime(2013, 1, 18, 22, 22, 6, DateTimeKind.Utc), 3));
            groupHistory.Messages.ShouldAllBeEquivalentTo(new[]
            {
                new Message
                {
                    Type = "message",
                    TimeSpan = new AccurateDateTime(new DateTime(2013, 1, 18, 22, 1, 55, DateTimeKind.Utc), 8),
                    UserId = "U2147483896",
                    Text = "Hello",
                    IsStarred = false
                },
                new Message
                {
                    Type = "message",
                    TimeSpan = new AccurateDateTime(new DateTime(2013, 1, 18, 22, 1, 55, DateTimeKind.Utc), 7),
                    UserId = "U2147483896",
                    Text = "World",
                    IsStarred = true
                },
                new Message
                {
                    Type = "something_else",
                    TimeSpan = new AccurateDateTime(new DateTime(2013, 1, 18, 22, 1, 55, DateTimeKind.Utc), 7)
                }
            });
        }

        [Test]
        public void GroupHistoryWithParameters()
        {
            CreateMockClient(@"{ ok: true}");

            WebApiClient.Groups.History(new Group {Id = "G12345"}, new GroupHistoryParameters
            {
                Count = 50,
                Inclusive = true,
                Latest = new AccurateDateTime(new DateTime(2013, 1, 18, 22, 1, 55, DateTimeKind.Utc), 7),
                Oldest = new AccurateDateTime(new DateTime(2013, 1, 18, 22, 1, 55, DateTimeKind.Utc), 7),
                Unreads = false
            });
            Connector.Commands.Last().Parameters.Should().Contain(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("channel", "G12345"),
                new KeyValuePair<string, string>("count", "50"),
                new KeyValuePair<string, string>("inclusive", "true"),
                new KeyValuePair<string, string>("latest", "1358546515.000007"),
                new KeyValuePair<string, string>("oldest", "1358546515.000007"),
                new KeyValuePair<string, string>("unreads", "false")
            });
        }
    }
}
