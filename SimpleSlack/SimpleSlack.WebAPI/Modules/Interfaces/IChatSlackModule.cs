using SimpleSlack.WebAPI.Models;

namespace SimpleSlack.WebAPI.Modules.Interfaces
{
    public interface IChatSlackModule
    {
        bool PostMessage(Group group, string message);
    }
}
