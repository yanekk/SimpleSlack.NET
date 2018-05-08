using System.Collections.Generic;
using SimpleSlack.WebAPI.Models;

namespace SimpleSlack.WebAPI.Modules.Interfaces
{
    public interface IUsersSlackModule
    {
        IList<User> List();
    }
}
