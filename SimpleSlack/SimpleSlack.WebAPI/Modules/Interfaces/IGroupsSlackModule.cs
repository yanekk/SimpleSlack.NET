using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Requests.Groups;
using SimpleSlack.WebAPI.Responses.Groups.Interfaces;

namespace SimpleSlack.WebAPI.Modules.Interfaces
{
    public interface IGroupsSlackModule
    {
        Group[] List(bool excludeArchived = false, bool excludeMembers = false);

        IGroupsHistoryResponse History(Group group);
        IGroupsHistoryResponse History(Group group, GroupHistoryParameters parameters);
    }
}
