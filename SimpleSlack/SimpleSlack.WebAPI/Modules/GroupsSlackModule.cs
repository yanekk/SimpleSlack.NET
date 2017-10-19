using SimpleSlack.WebAPI.Core.Connectors;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Modules.Interfaces;
using SimpleSlack.WebAPI.Requests.Groups;
using SimpleSlack.WebAPI.Responses.Groups;
using SimpleSlack.WebAPI.Responses.Groups.Interfaces;

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

        public IGroupsHistoryResponse History(Group group)
        {
            return History(group, new GroupHistoryParameters());
        }

        public IGroupsHistoryResponse History(Group group, GroupHistoryParameters parameters)
        {
            return Execute<GroupsHistoryResponse>(new GroupsHistoryRequest
            {
                Channel = group.Id,
                Count = parameters.Count,
                Inclusive = parameters.Inclusive,
                Oldest = parameters.Oldest,
                Latest = parameters.Latest,
                Unreads = parameters.Unreads
            });
        }
    }
}
