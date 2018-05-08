using System.Collections.Generic;
using SimpleSlack.WebAPI.Core.Connectors;
using SimpleSlack.WebAPI.Models;
using SimpleSlack.WebAPI.Modules.Interfaces;
using SimpleSlack.WebAPI.Requests.Users;
using SimpleSlack.WebAPI.Responses.Users;

namespace SimpleSlack.WebAPI.Modules
{
    internal class UsersSlackModule : SlackModule, IUsersSlackModule
    {
        public UsersSlackModule(string token, ISlackConnector connector) : base(token, connector)
        {
        }

        public IList<User> List()
        {
            var result = Execute<UsersListResponse>(new UsersListRequest());
            return result.Members;
        }
    }
}
