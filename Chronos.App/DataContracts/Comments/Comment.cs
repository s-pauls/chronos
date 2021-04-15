using System;

namespace Chronos.App.DataContracts.Comments
{
    public class Comment
    {
        public int CommentId { get; set; }
        public DateTime DateTime { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public bool IsCustom { get; set; }
    }
}
