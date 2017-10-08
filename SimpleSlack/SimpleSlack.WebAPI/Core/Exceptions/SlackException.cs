using System;

namespace SimpleSlack.WebAPI.Core.Exceptions
{
    public class SlackException : Exception
    {
        public string ErrorName { get; private set; }
        public SlackException(string errorName) : base($"Slack response error: {errorName}")
        {
            ErrorName = errorName;
        }
    }
}
