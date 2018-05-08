using System;

namespace SimpleSlack.WebAPI.Models
{
    public class AccurateDateTime : IComparable<AccurateDateTime>
    {
        public DateTime DateTime { get; }
        public long Tick { get; }

        public AccurateDateTime(DateTime dateTime) : this(dateTime, 1)
        {
            
        }

        public AccurateDateTime(DateTime dateTime, long tick)
        {
            DateTime = dateTime;
            Tick = tick;
        }

        public int CompareTo(AccurateDateTime other)
        {
            return (DateTime.Ticks + Tick).CompareTo(other.DateTime.Ticks + other.Tick);
        }

        public override bool Equals(object obj)
        {
            var accurateDateTime = obj as AccurateDateTime;
            if (accurateDateTime != null)
                return DateTime == accurateDateTime.DateTime && Tick == accurateDateTime.Tick;
            return base.Equals(obj);
        }
    }
}
