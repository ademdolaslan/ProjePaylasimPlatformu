using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSharing.UI.Models
{
    public class SubCommentViewModel
    {
        public int PageID { get; set; }
        public int ParentCommentID { get; set; }
        public string CommentTitle { get; set; }
        public string CommentText { get; set; }
    }
}
