using SimpleSlack.WebAPI.Models;

namespace SimpleSlack.WebAPI.Responses.Groups.Interfaces
{
    public interface IGroupsHistoryResponse
    {
        AccurateDateTime Latest { get; }
        Message[] Messages { get; }
        bool HasMore { get; }
        bool IsLimited { get; }
    }
}
