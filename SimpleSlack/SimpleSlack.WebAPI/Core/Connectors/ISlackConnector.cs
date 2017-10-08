using System.Collections.Generic;

namespace SimpleSlack.WebAPI.Core.Connectors
{
    internal interface ISlackConnector
    {
        string Send(string command, Dictionary<string, string> parameters);
    }
}
