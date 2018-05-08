namespace SimpleSlack.WebAPI.Requests.Common
{
    public class AttachmentFieldRequest
    {
        internal string Title { get; set; }
        internal string Value { get; set; }
        internal bool IsShort { get; set; }

        public AttachmentFieldRequest(string title, string value, bool isShort = false)
        {
            Title = title;
            Value = value;
            IsShort = isShort;
        }
    }
}
