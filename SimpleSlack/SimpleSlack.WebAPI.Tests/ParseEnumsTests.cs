using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SimpleSlack.WebAPI.Enumerations;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Requests.Chat;
using SimpleSlack.WebAPI.Tests.Common;

namespace SimpleSlack.WebAPI.Tests
{
    [TestFixture]
    internal class EnumParsingTests : SlackTestsBase
    {
        [Test]
        public void ParseEnumTest()
        {
            CreateMockClient(@"{
                ""ok"": true,
                ""ts"": ""1405895017.000506"",
                ""channel"": ""C024BE91L"",
                ""message"": """"
            }");

            WebApiClient.Chat.PostMessage(new Group { Id = "12345" }, new GroupMessage
            {
                Message = "Test Message",
                Parse = ParseMessage.Full
            });
            
            Connector.Commands.Last().Parameters.Should().Contain(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("parse", "full")
            });
        }

        [Test]
        public void ParseEnumDefaultValue()
        {
            CreateMockClient(@"{
                ""ok"": true,
                ""ts"": ""1405895017.000506"",
                ""channel"": ""C024BE91L"",
                ""message"": """"
            }");

            WebApiClient.Chat.PostMessage(new Group { Id = "12345" }, "test message");
            Connector.Commands.Last().Parameters.Should().NotContainKey("parse");
        }
    }
}
