namespace SimpleSlack.WebAPI.Requests.Users
{
    internal class UsersListRequest : BaseRequest
    {
        internal override string Command
        {
            get { return "users.list"; }
        }
    }
}
