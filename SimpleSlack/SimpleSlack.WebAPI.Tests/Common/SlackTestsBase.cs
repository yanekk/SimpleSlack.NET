using System;

namespace SimpleSlack.WebAPI.Tests.Common
{
    internal class SlackTestsBase
    {
        protected SlackWebApiClient WebApiClient { get; set; }
        protected MockSlackConnector Connector { get; set; }

        protected void CreateMockClient(string response)
        {
            CreateMockClient(() => response);
        }

        protected void CreateMockClient(Func<string> closure)
        {
            Connector = new MockSlackConnector(closure);
            WebApiClient = new SlackWebApiClient("##token##", Connector);
        }
    }
}
