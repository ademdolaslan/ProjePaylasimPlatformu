using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectSharing.DAL.Entities
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }        
        public string UserID { get; set; }
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
        public string PageContent { get; set; }        
        public string PageUrl { get; set; }        
        public int PageCategoryID { get; set; }
        public string PageTags { get; set; }
        public int PageViewCount { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsVerified { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        [ForeignKey("PageCategoryID")]
        public Category Category { get; set; }


        public ICollection<File> File { get; set; }
        public ICollection<Comment> Comment { get; set; }

    }
}
