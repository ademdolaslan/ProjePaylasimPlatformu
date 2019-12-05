using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectSharing.DAL.Entities
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int? CommentParentID { get; set; }
        public int PageID { get; set; }
        public string UserID { get; set; }
        public string CommentTitle { get; set; }
        public string CommentText { get; set; }
        public int Rating { get; set; }
        public bool IsVerified { get; set; }


        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("PageID")]
        public Page Page { get; set; }

      
    }
}
