using System.Collections.Generic;

namespace SimpleSlack.WebAPI.Tests.Common
{
    internal class SlackCommand
    {
        public string CommandName { get; set; }
        public Dictionary<string, string> Parameters { get; set; }

        public SlackCommand(string commandName, Dictionary<string, string> parameters)
        {
            CommandName = commandName;
            Parameters = parameters;
        }
    }
}
