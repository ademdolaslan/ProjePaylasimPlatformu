using ProjectSharing.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectSharing.DAL.Models
{
    public class PageCountByCategory
    {
        public Category Category { get; set; }
        public int Count { get; set; }
    }
}
