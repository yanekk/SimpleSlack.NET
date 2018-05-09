using System.Collections.Generic;
using SimpleSlack.WebAPI.Models;

namespace SimpleSlack.WebAPI.Modules.Interfaces
{
    public interface IDirectMessagesModule
    {
        IList<DirectMessageChannel> Channels();
        DirectMessageChannel OpenChannel(User user);
    }
}
