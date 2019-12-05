using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSharing.UI.Models
{
    public class HtmlTextViewModel
    {
        public string HtmlText { get; set; }
        public IFormFile PageFiles { get; set; }
        public int PageCategory { get; set; }
        public string PageTags { get; set; }
        public string PageTitle { get; set; }
        public string PageDescription { get; set; }
    }
}
