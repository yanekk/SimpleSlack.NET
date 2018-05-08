using NUnit.Framework;

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
    }
}
