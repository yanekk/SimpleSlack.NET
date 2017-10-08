using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SimpleSlack.WebAPI.Enumerations;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Requests.Chat;

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
            client.Chat.PostMessage(myGroup, new GroupMessage
            {
                Message = "this is the message",
                AsUser = false,
                Attachments = new List<Attachment>(),
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
    }
}
