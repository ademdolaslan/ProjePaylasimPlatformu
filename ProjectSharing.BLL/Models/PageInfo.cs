using ProjectSharing.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSharing.BLL.Models
{
    public class PageInfo
    {
        public Page Page { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
    }
}
