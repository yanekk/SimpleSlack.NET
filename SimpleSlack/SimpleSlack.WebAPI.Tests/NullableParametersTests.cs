using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Requests.Chat;
using SimpleSlack.WebAPI.Tests.Common;

namespace SimpleSlack.WebAPI.Tests
{
    [TestFixture]
    internal class NullableParametersTests : SlackTestsBase
    {
        [Test]
        public void PropertyWithNullValueIsOmitted()
        {
            CreateMockClient(@"{
                ""ok"": true,
                ""ts"": ""1405895017.000506"",
                ""channel"": ""C024BE91L"",
                ""message"": """"
            }");
            WebApiClient.Chat.PostMessage(new Group { Id = "12345" }, new GroupMessageParameters
            {
                Message = "Test Message",
                AsUser = true,
                UnfurlLinks = false,
                UnfurlMedia = null
            });

            var lastCommand = Connector.Commands.Last();
            lastCommand.Parameters.Should().Contain(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("text", "Test Message"),
                new KeyValuePair<string, string>("as_user", "true"),
                new KeyValuePair<string, string>("unfurl_links", "false")
            });

            lastCommand.Parameters.Should().NotContainKeys(new List<string>
            {
                "unfurl_media",
                "link_names",
                "user_name"
            });
        }
    }
}
