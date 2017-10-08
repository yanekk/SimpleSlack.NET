using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SimpleSlack.WebAPI.Core.Connectors
{
    internal class SlackConnector : ISlackConnector
    {
        private static string BaseUrl = "https://slack.com/api/";

        public string Send(string command, Dictionary<string, string> parameters)
        {
            var request = WebRequest.CreateHttp(BaseUrl + command);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            var queryString = BuildRequestString(parameters);
            request.ContentLength = queryString.Length;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(queryString, 0, queryString.Length);
            }
            var response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }

        private byte[] BuildRequestString(Dictionary<string, string> parameters)
        {
            var queryString = string.Join("&",
                parameters.Select(kv =>
                {
                    var key = HttpUtility.UrlEncode(kv.Key);
                    var value = HttpUtility.UrlEncode(kv.Value);
                    return key + "=" + value;
                }));
            return Encoding.UTF8.GetBytes(queryString);
        }
    }
}
