using System.Collections.Generic;
using SimpleSlack.WebAPI.Enumerations;
using SimpleSlack.WebAPI.Requests.Common;

namespace SimpleSlack.WebAPI.Requests.Chat
{
    public class GroupMessageParameters
    {
        /// <summary>
        /// Required. Text of the message to send.
        /// </summary>
        public string Message;

        /// <summary>
        /// Optional. Pass true to post the message as the authed user, instead of as a bot.
        /// </summary>
        public bool? AsUser;

        /// <summary>
        /// Optional. An array of attachments. Defaults to false. 
        /// </summary>
        public List<AttachmentRequest> Attachments;

        /// <summary>
        /// Optional. Emoji to use as the icon for this message.Overrides icon_url.Must be used in conjunction with as_user set to false, otherwise ignored.
        /// </summary>
        public string IconEmoji;

        /// <summary>
        /// Optional. URL to an image to use as the icon for this message.Must be used in conjunction with as_user set to false, otherwise ignored.
        /// </summary>
        public string IconUrl;

        /// <summary>
        /// Optional. Find and link channel names and usernames. Defaults to true.
        /// </summary>
        public bool? LinkNames;

        /// <summary>
        /// Optional. Change how messages are treated. Defaults to none.
        /// </summary>
        public ParseMessage Parse;

        /// <summary>
        /// Optional. Used in conjunction with thread_ts and indicates whether reply should be made visible to everyone in the channel or conversation. Defaults to false.
        /// </summary>
        public bool? ReplyBroadcast;

        /// <summary>
        /// Optional. Provide another message's ts value to make this message a reply. Avoid using a reply's ts value; use its parent instead.
        /// </summary>
        public string ThreadTs;

        /// <summary>
        /// Optional. Pass true to enable unfurling of primarily text-based content. Defaults to false.
        /// </summary>
        public bool? UnfurlLinks;

        /// <summary>
        /// Optional. Pass false to disable unfurling of media content. Defaults to false
        /// </summary>
        public bool? UnfurlMedia;

        /// <summary>
        /// Optional. Set your bot's user name. Must be used in conjunction with as_user set to false, otherwise ignored.
        /// </summary>
        public string UserName;
    }
}
