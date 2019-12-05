using ProjectSharing.DAL.Entities;
using System.Collections.Generic;

namespace ProjectSharing.UI.Models
{
    public class PageInfoViewModel
    {
        public Page PageInfo { get; set; }
        public List<Comment> PageComments { get; set; }
        public List<File> PageFiles { get; set; }
    }
}
