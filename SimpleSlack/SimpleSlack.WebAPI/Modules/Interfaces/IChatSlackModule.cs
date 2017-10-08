using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Requests.Chat;

namespace SimpleSlack.WebAPI.Modules.Interfaces
{
    public interface IChatSlackModule
    {
        bool PostMessage(Group group, string message);
        bool PostMessage(Group group, GroupMessage message);
    }
}
