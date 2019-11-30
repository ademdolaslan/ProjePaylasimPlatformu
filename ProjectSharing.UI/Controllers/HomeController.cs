using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectSharing.BLL;
using ProjectSharing.UI.Models;

namespace ProjectSharing.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly PageBLL pageBLL = new PageBLL();
        public IActionResult Index()
        {
            var _model = pageBLL.PagesWithFullDescription();
            return View(_model);
        }     
    }
}
