using SimpleSlack.WebAPI.Connectors;
using SimpleSlack.WebAPI.Modules;
using SimpleSlack.WebAPI.Modules.Interfaces;

namespace SimpleSlack.WebAPI
{
    public class SlackWebApiClient
    {
        public readonly IChatSlackModule Chat;
        public readonly IGroupsSlackModule Groups;

        public SlackWebApiClient(string token) : this(token, new SlackConnector())
        {
            
        }

        internal SlackWebApiClient(string token, ISlackConnector connector)
        {
            Chat = new ChatSlackModule(token, connector);
            Groups = new GroupsSlackModule(token, connector);
        }
    }
}
