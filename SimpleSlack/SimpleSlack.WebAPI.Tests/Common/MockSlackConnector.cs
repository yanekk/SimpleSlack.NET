using System;
using System.Collections.Generic;
using SimpleSlack.WebAPI.Core.Connectors;

namespace SimpleSlack.WebAPI.Tests.Common
{
    internal class MockSlackConnector : ISlackConnector
    {
        private readonly Func<string> _closure;

        public MockSlackConnector(Func<string> closure)
        {
            _closure = closure;
        }

        public List<SlackCommand> Commands = new List<SlackCommand>();
        public string Send(string command, Dictionary<string, string> parameters)
        {
            Commands.Add(new SlackCommand(command, parameters));
            return _closure.Invoke();
        }
    }
}
