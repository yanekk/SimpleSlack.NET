using System.Collections.Generic;

namespace SimpleSlack.WebAPI.Connectors
{
    internal interface ISlackConnector
    {
        string Send(string command, Dictionary<string, string> parameters);
    }
}
