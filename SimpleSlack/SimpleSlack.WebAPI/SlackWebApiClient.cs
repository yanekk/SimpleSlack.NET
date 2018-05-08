using SimpleSlack.WebAPI.Core.Connectors;
using SimpleSlack.WebAPI.Modules;
using SimpleSlack.WebAPI.Modules.Interfaces;

namespace SimpleSlack.WebAPI
{
    public class SlackWebApiClient
    {
        public readonly IChatSlackModule Chat;
        public readonly IGroupsSlackModule Groups;
        public readonly IUsersSlackModule Users;

        public SlackWebApiClient(string token) : this(token, new SlackConnector())
        {
            
        }

        internal SlackWebApiClient(string token, ISlackConnector connector)
        {
            Chat = new ChatSlackModule(token, connector);
            Groups = new GroupsSlackModule(token, connector);
            Users = new UsersSlackModule(token, connector);
        }
    }
}
