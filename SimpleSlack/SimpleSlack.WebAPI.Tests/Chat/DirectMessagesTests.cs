using FluentAssertions;
using NUnit.Framework;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Tests.Common;

namespace SimpleSlack.WebAPI.Tests.Chat
{
    [TestFixture]
    internal class DirectMessagesTests : SlackTestsBase
    {
        [Test]
        public void GetChannelList()
        {
            CreateMockClient(@"{
                ""ok"": true,
                ""ims"": [
                    {
                        ""id"": ""D0G9QPY56"",
                        ""created"": 1449709280,
                        ""is_im"": true,
                        ""is_org_shared"": false,
                        ""user"": ""USLACKBOT"",
                        ""is_user_deleted"": false
                    },
                    {
                        ""id"": ""D1KL59A72"",
                        ""created"": 1466692204,
                        ""is_im"": true,
                        ""is_org_shared"": false,
                        ""user"": ""U0G9QF9C6"",
                        ""is_user_deleted"": false
                    }
                ],
                ""response_metadata"": {
                    ""next_cursor"": ""aW1faWQ6RDBCSDk1RExI=""
                }
            }");
            var channels = WebApiClient.DirectMessages.Channels();
            Assert.AreEqual(2, channels.Count);
            channels[0].ShouldBeEquivalentTo(new DirectMessageChannel
            {
                Id = "D0G9QPY56",
                Created = 1449709280,
                IsIm = true,
                IsOrgShared = false,
                UserId = "USLACKBOT",
                IsUserDeleted = false
            });
        }


        [Test]
        public void CreateChannel()
        {
            CreateMockClient(@"{
                ""ok"": true,
                ""channel"": {
                    ""id"": ""D947RLWRX""
                }
            }");
            var channel = WebApiClient.DirectMessages.OpenChannel(new User {Id = "user-id"});
            Assert.AreEqual("D947RLWRX", channel.Id);
        }
    }
}
