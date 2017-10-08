namespace SimpleSlack.WebAPI.Requests.Common
{
    public class AttachmentField
    {
        internal string Title { get; set; }
        internal string Value { get; set; }
        internal bool IsShort { get; set; }

        public AttachmentField(string title, string value, bool isShort = false)
        {
            Title = title;
            Value = value;
            IsShort = isShort;
        }
    }
}
