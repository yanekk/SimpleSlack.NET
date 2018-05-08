using FluentAssertions;
using NUnit.Framework;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Tests.Common;

namespace SimpleSlack.WebAPI.Tests.Users
{
    [TestFixture]
    internal class UserListTests : SlackTestsBase
    {
        private string DefaultResponse = @"{
    ""ok"": true,
    ""members"": [
        {
            ""id"": ""W012A3CDE"",
            ""team_id"": ""T012AB3C4"",
            ""name"": ""spengler"",
            ""deleted"": false,
            ""color"": ""9f69e7"",
            ""real_name"": ""spengler"",
            ""tz"": ""America\/Los_Angeles"",
            ""tz_label"": ""Pacific Daylight Time"",
            ""tz_offset"": -25200,
            ""profile"": {
                ""avatar_hash"": ""ge3b51ca72de"",
                ""status_text"": ""Print is dead"",
                ""status_emoji"": "":books:"",
                ""real_name"": ""Egon Spengler"",
                ""display_name"": ""spengler"",
                ""real_name_normalized"": ""Egon Spengler"",
                ""display_name_normalized"": ""spengler"",
                ""email"": ""spengler@ghostbusters.example.com"",
                ""image_24"": ""https:\/\/...\/avatar\/e3b51ca72dee4ef87916ae2b9240df50.jpg"",
                ""image_32"": ""https:\/\/...\/avatar\/e3b51ca72dee4ef87916ae2b9240df50.jpg"",
                ""image_48"": ""https:\/\/...\/avatar\/e3b51ca72dee4ef87916ae2b9240df50.jpg"",
                ""image_72"": ""https:\/\/...\/avatar\/e3b51ca72dee4ef87916ae2b9240df50.jpg"",
                ""image_192"": ""https:\/\/...\/avatar\/e3b51ca72dee4ef87916ae2b9240df50.jpg"",
                ""image_512"": ""https:\/\/...\/avatar\/e3b51ca72dee4ef87916ae2b9240df50.jpg"",
                ""team"": ""T012AB3C4""
            },
            ""is_admin"": true,
            ""is_owner"": false,
            ""is_primary_owner"": false,
            ""is_restricted"": false,
            ""is_ultra_restricted"": false,
            ""is_bot"": false,
            ""updated"": 1502138686,
            ""is_app_user"": false,
            ""has_2fa"": false
        },
        {
            ""id"": ""W07QCRPA4"",
            ""team_id"": ""T0G9PQBBK"",
            ""name"": ""glinda"",
            ""deleted"": false,
            ""color"": ""9f69e7"",
            ""real_name"": ""Glinda Southgood"",
            ""tz"": ""America\/Los_Angeles"",
            ""tz_label"": ""Pacific Daylight Time"",
            ""tz_offset"": -25200,
            ""profile"": {
                ""avatar_hash"": ""8fbdd10b41c6"",
                ""image_24"": ""https:\/\/a.slack-edge.com...png"",
                ""image_32"": ""https:\/\/a.slack-edge.com...png"",
                ""image_48"": ""https:\/\/a.slack-edge.com...png"",
                ""image_72"": ""https:\/\/a.slack-edge.com...png"",
                ""image_192"": ""https:\/\/a.slack-edge.com...png"",
                ""image_512"": ""https:\/\/a.slack-edge.com...png"",
                ""image_1024"": ""https:\/\/a.slack-edge.com...png"",
                ""image_original"": ""https:\/\/a.slack-edge.com...png"",
                ""first_name"": ""Glinda"",
                ""last_name"": ""Southgood"",
                ""title"": ""Glinda the Good"",
                ""phone"": """",
                ""skype"": """",
                ""real_name"": ""Glinda Southgood"",
                ""real_name_normalized"": ""Glinda Southgood"",
                ""display_name"": ""Glinda the Fairly Good"",
                ""display_name_normalized"": ""Glinda the Fairly Good"",
                ""email"": ""glenda@south.oz.coven""
            },
            ""is_admin"": true,
            ""is_owner"": false,
            ""is_primary_owner"": false,
            ""is_restricted"": false,
            ""is_ultra_restricted"": false,
            ""is_bot"": false,
            ""updated"": 1480527098,
            ""has_2fa"": false
        }
    ],
    ""cache_ts"": 1498777272,
    ""response_metadata"": {
        ""next_cursor"": ""dXNlcjpVMEc5V0ZYTlo=""
    }
}";

        [Test]
        public void GetUserList()
        {
            CreateMockClient(DefaultResponse);
            var users = WebApiClient.Users.List();
            Assert.AreEqual(2, users.Count);
            users[0].ShouldBeEquivalentTo(new User
            {
                Id = "W012A3CDE",
                TeamId = "T012AB3C4",
                Name = "spengler",
                IsDeleted = false,
                Color = "9f69e7",
                RealName = "spengler",
                TimeZone = "America/Los_Angeles",
                TimeZoneLabel = "Pacific Daylight Time",
                TimeZoneOffset = -25200,
                Profile = new UserProfile
                {
                    AvatarHash = "ge3b51ca72de",
                    StatusText = "Print is dead",
                    StatusEmoji = ":books:",
                    RealName = "Egon Spengler",
                    DisplayName = "spengler",
                    DisplayNameNormalized = "spengler",
                    RealNameNormalized = "Egon Spengler",
                    Email = "spengler@ghostbusters.example.com",
                    ImageUrl24 = "https://.../avatar/e3b51ca72dee4ef87916ae2b9240df50.jpg",
                    ImageUrl32 = "https://.../avatar/e3b51ca72dee4ef87916ae2b9240df50.jpg",
                    ImageUrl48 = "https://.../avatar/e3b51ca72dee4ef87916ae2b9240df50.jpg",
                    ImageUrl72 = "https://.../avatar/e3b51ca72dee4ef87916ae2b9240df50.jpg",
                    ImageUrl192 = "https://.../avatar/e3b51ca72dee4ef87916ae2b9240df50.jpg",
                    ImageUrl512 = "https://.../avatar/e3b51ca72dee4ef87916ae2b9240df50.jpg",
                    Team = "T012AB3C4"
                },
                IsAdmin = true,
                IsOwner = false,
                IsPrimaryOwner = false,
                IsRestricted = false,
                IsUltraRestricted = false,
                IsBot = false,
                Updated = 1502138686,
                IsAppUser = false,
                Has2Fa = false
            });
        }
    }
}
