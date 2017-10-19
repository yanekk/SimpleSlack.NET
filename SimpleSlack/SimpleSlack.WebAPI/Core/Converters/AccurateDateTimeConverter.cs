using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using SimpleSlack.WebAPI.Models;

namespace SimpleSlack.WebAPI.Core.Converters
{
    internal class AccurateDateTimeConverter : JsonConverter
    {
        private static readonly Regex AccurateTimeSpanPattern = new Regex(@"^(\d+?)\.(\d+?)$");
        private static DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var accurateDateTime = (AccurateDateTime) value;
            if (accurateDateTime == null)
            {
                writer.WriteNull();
                return;
            }
            var seconds = (accurateDateTime.DateTime - _epoch).TotalSeconds;
            var stringValue = string.Format("{0}.{1}", seconds, accurateDateTime.Tick.ToString().PadLeft(6, '0'));
            writer.WriteRaw(stringValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var timespanMatch = AccurateTimeSpanPattern.Match((string) reader.Value);
            var ticks = long.Parse(timespanMatch.Groups[1].Value);
            var tick = long.Parse(timespanMatch.Groups[2].Value);
            return new AccurateDateTime(_epoch.AddSeconds(ticks), tick);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}
