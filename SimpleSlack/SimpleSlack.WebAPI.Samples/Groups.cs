using System.Linq;
using NUnit.Framework;

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
    }
}
