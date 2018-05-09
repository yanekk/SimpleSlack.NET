using System.Linq;
using NUnit.Framework;
using SimpleSlack.WebAPI.Enumerations;
using SimpleSlack.WebAPI.Requests.Chat;

namespace SimpleSlack.WebAPI.Samples
{
    [TestFixture]
    internal class Users
    {
        [Test]
        public void GetUserList()
        {
            // initialize client with app token
            var client = new SlackWebApiClient("## api-token ##");

            // get users list
            var users = client.Users.List();
        }

        [Test]
        public void SendUserMessage()
        {
            // initialize client with app token
            var client = new SlackWebApiClient("## api-token ##");

            // get users list
            var user = client.Users.List()
                .FirstOrDefault(u => u.Name == "user.name");

            // find communication channel
            var channel = client.DirectMessages.Channels()
                .FirstOrDefault(c => c.UserId == user.Id);

            // open channel if it's not created yet
            if (channel == null)
                channel = client.DirectMessages.OpenChannel(user);

            // post message
            client.Chat.PostMessage(channel, new MessageParameters
            {
                Message = "this is the message",
                AsUser = false,
                IconEmoji = ":chart_with_upwards_trend:",
                IconUrl = "http://lorempixel.com/48/4",
                LinkNames = false,
                Parse = ParseMessage.Full,
                ReplyBroadcast = false,
                UnfurlLinks = false,
                UnfurlMedia = true,
                UserName = "Tom Hanks"
            });
        }
    }
}
