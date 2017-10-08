using System;
using FluentAssertions;
using NUnit.Framework;
using SimpleSlack.WebAPI.Exceptions;
using SimpleSlack.WebAPI.Tests.Common;

namespace SimpleSlack.WebAPI.Tests
{
    [TestFixture]
    internal class ErrorTests : SlackTestsBase
    {
        [Test]
        public void ErrorResponseTest()
        {
            CreateMockClient(@"{
                ""ok"": false,
                ""error"": ""something_bad""
            }");
            
            Action action = () => WebApiClient.Groups.List();
            action.ShouldThrow<SlackException>().And.ErrorName.Should().Be("something_bad");
        }
    }
}
