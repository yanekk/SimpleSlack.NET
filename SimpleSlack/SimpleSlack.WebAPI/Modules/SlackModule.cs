using Newtonsoft.Json;
using SimpleSlack.WebAPI.Connectors;
using SimpleSlack.WebAPI.Exceptions;
using SimpleSlack.WebAPI.Requests;
using SimpleSlack.WebAPI.Responses;

namespace SimpleSlack.WebAPI.Modules
{
    internal abstract class SlackModule
    {
        private readonly string _token;
        private readonly ISlackConnector _connector;

        internal SlackModule(string token, ISlackConnector connector)
        {
            _token = token;
            _connector = connector;
        }

        protected TResponse Execute<TResponse>(BaseRequest request)
            where TResponse : BaseResponse
        {
            request.Token = _token;
            var response = _connector.Send(request.Command, request.BuildQuery());
            var jsonResponse = JsonConvert.DeserializeObject<TResponse>(response);
            if (!jsonResponse.Ok)
                throw new SlackException(jsonResponse.Error);
            return jsonResponse;
        }
    }
}
