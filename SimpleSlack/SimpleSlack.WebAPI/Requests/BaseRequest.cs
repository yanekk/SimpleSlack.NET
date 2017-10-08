using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using SimpleSlack.WebAPI.Core.Attributes;

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
                .Where(p =>
                {
                    var propertyValue = p.GetValue(this);
                    if (p.PropertyType.IsEnum)
                        return (int) propertyValue != 0;

                    return propertyValue != null;
                })
                .ToDictionary(
                    p => p.GetCustomAttribute<JsonPropertyAttribute>().PropertyName,
                    p =>
                    {
                        var propertyType = p.PropertyType;
                        var propertyValue = p.GetValue(this);

                        if (propertyType == typeof(string))
                            return (string)propertyValue;
                        if (propertyType.IsEnum)
                        {
                            var name = Enum.GetName(propertyType, propertyValue);
                            var valueAttribute = propertyType.GetField(name)
                                .GetCustomAttribute<MemberValueAttribute>();
                            if (valueAttribute != null)
                            {
                                return valueAttribute.Value;
                            }
                        }
                        return JsonConvert.SerializeObject(propertyValue);
                    });
        }
    }
}
