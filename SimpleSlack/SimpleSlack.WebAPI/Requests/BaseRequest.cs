using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace SimpleSlack.WebAPI.Requests
{
    internal abstract class BaseRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        internal abstract string Command { get; }

        public Dictionary<string, string> BuildQuery()
        {
            return GetType().GetProperties()
                .Where(p => p.GetCustomAttribute<JsonPropertyAttribute>() != null)
                .ToDictionary(
                    p => p.GetCustomAttribute<JsonPropertyAttribute>().PropertyName,
                    p =>
                    {
                        var value = p.GetValue(this);
                        return value is string 
                            ? (string)value 
                            : JsonConvert.ToString(value);
                    });
        }
    }
}
