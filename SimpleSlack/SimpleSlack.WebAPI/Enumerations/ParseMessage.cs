﻿using SimpleSlack.WebAPI.Attributes;

namespace SimpleSlack.WebAPI.Enumerations
{
    public enum ParseMessage
    {
        Unknown,

        [MemberValue("none")]
        None,

        [MemberValue("full")]
        Full
    }
}
