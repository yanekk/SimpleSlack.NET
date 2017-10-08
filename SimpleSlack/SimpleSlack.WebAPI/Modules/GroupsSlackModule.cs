using SimpleSlack.WebAPI.Connectors;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Modules.Interfaces;
using SimpleSlack.WebAPI.Requests.Groups;
using SimpleSlack.WebAPI.Responses.Groups;

namespace SimpleSlack.WebAPI.Modules
{
    internal class GroupsSlackModule : SlackModule, IGroupsSlackModule
    {
        public GroupsSlackModule(string token, ISlackConnector connector) : base(token, connector)
        {

        }

        public Group[] List(bool excludeArchived = false, bool excludeMembers = false)
        {
            var result = Execute<GroupsListResponse>(new GroupsListRequest
            {
                ExcludeArchived = excludeArchived,
                ExcludeMembers = excludeMembers
            });
            return result.Groups;
        }
    }
}
