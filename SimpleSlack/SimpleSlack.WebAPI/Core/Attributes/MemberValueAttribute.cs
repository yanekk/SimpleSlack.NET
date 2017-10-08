using System;

namespace SimpleSlack.WebAPI.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    internal class MemberValueAttribute : Attribute
    {
        public string Value { get; private set; }

        public MemberValueAttribute(string value)
        {
            Value = value;
        }
    }
}
