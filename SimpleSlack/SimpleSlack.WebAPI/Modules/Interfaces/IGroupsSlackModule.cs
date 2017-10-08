using SimpleSlack.WebAPI.Models;

namespace SimpleSlack.WebAPI.Modules.Interfaces
{
    public interface IGroupsSlackModule
    {
        Group[] List(bool excludeArchived = false, bool excludeMembers = false);
    }
}
