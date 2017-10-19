using System;
using System.Collections.Generic;
using SimpleSlack.WebAPI.Models;

namespace SimpleSlack.WebAPI.Requests.Common
{
    public class AttachmentRequest
    {
        /// <summary>
        /// Required plain-text summary of the attachment.
        /// </summary>
        public string Fallback { get; set; }

        /// <summary>
        /// Colour of strip located on the left of the text.
        /// </summary>
        public Colour Color { get; set; }

        /// <summary>
        /// Optional text that appears above the attachment block.
        /// </summary>
        public string Pretext { get; set; }

        /// <summary>
        /// Name of the author
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Link to author
        /// </summary>
        public string AuthorLink { get; set; }

        /// <summary>
        /// Author icon
        /// </summary>
        public string AuthorIcon { get; set; }

        /// <summary>
        /// Attachment's title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Attachment's title link
        /// </summary>
        public string TitleLink { get; set; }

        /// <summary>
        /// Attachment's text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Attachment's fields
        /// </summary>
        public List<AttachmentFieldRequest> Fields { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbUrl { get; set; }

        public string Footer { get; set; }

        public string FooterIcon { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
