using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectSharing.UI.Models;

namespace ProjectSharing.UI.Controllers
{
    [Authorize(Roles ="Admin,User,Editor")]
    public class ProjectController : Controller
    {
        public IActionResult Share()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SavePage(HtmlTextViewModel model)
        {

            return Json(model.HtmlText);

        }
    }
}