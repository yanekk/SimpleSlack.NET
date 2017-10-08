using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Tests.Common;

namespace SimpleSlack.WebAPI.Tests.Chat
{
    [TestFixture]
    internal class PostMessageTests : SlackTestsBase
    {
        [Test]
        public void PostMessageTest()
        {
            CreateMockClient(@"{
                ""ok"": true,
                ""ts"": ""1405895017.000506"",
                ""channel"": ""C024BE91L"",
                ""message"": """"
            }");
            WebApiClient.Chat.PostMessage(new Group {Id = "12345"}, "Test");

            var lastCommand = Connector.Commands.Last();
            lastCommand.CommandName.Should().Be("chat.postMessage");
            lastCommand.Parameters.Should().Contain(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("channel", "12345"),
                new KeyValuePair<string, string>("text", "Test")
            });
        }
    }
}
