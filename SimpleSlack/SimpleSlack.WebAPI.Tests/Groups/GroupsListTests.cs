using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Tests.Common;

namespace SimpleSlack.WebAPI.Tests.Groups
{
    [TestFixture]
    internal class GroupsListTests : SlackTestsBase
    {
        [Test]
        public void GetGroupsListTest()
        {
            CreateMockClient(@"{
                ""ok"": true,
                ""groups"": [
                    {
                        ""id"": ""G024BE91L"",
                        ""name"": ""secretplans"",
                        ""created"": 1360782804,
                        ""creator"": ""U024BE7LH"",
                        ""is_archived"": false,
                        ""members"": [
                            ""U024BE7LH""
                        ],
                        ""topic"": {
                            ""value"": ""Secret plans on hold"",
                            ""creator"": ""U024BE7LV"",
                            ""last_set"": 1369677212
                        },
                        ""purpose"": {
                            ""value"": ""Discuss secret plans that no-one else should know"",
                            ""creator"": ""U024BE7LH"",
                            ""last_set"": 1360782804
                        }
                    }
                ]
            }");
            
            var groups = WebApiClient.Groups.List();
            var lastCommand = Connector.Commands.Last();
            lastCommand.Parameters.Should().Contain(new[]
            {
                new KeyValuePair<string, string>("exclude_archived", "false"),
                new KeyValuePair<string, string>("exclude_members", "false")
            });

            Connector.Commands.Last().CommandName.Should().Be("groups.list");

            Assert.AreEqual(1, groups.Length);
            var group = groups[0];
            group.ShouldBeEquivalentTo(new Group
            {
                Id = "G024BE91L",
                Name = "secretplans",
                Created = 1360782804,
                Creator = "U024BE7LH",
                IsArchived = false,
                Members = new [] { "U024BE7LH" },
                Topic = new Topic
                {
                    Value = "Secret plans on hold",
                    Creator = "U024BE7LV",
                    LastSet = 1369677212
                },
                Purpose = new Purpose
                {
                    Value = "Discuss secret plans that no-one else should know",
                    Creator = "U024BE7LH",
                    LastSet = 1360782804
                }
            });
        }
    }
}
