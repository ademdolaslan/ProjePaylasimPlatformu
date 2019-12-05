using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSharing.UI.Models
{
    public class CommentViewModel
    {
        public int PageID { get; set; }
        public string UserID { get; set; }
        public string CommentTitle { get; set; }
        public string CommentText { get; set; }
    }
}
