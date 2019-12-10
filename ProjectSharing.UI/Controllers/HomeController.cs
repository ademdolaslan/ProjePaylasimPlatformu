using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProjectSharing.BLL;
using ProjectSharing.DAL.Entities;
using ProjectSharing.UI.Models;

namespace ProjectSharing.UI.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        private readonly PageBLL pageBLL = new PageBLL();      
        public HomeController(IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            var _model = pageBLL.GetAllPages();
            return View(_model);
        }
        
        public FileContentResult FileContent(string id)
        {
            var user = new UserBLL().GetUserByID(id);

            if (user.Picture == null)
            {                
                var path = Path.Combine(hostingEnvironment.WebRootPath,"images/user.png");
                return new FileContentResult(new UserBLL().ImageToByteArray(Image.FromFile(path)), "image/png");
            }
            else
            {
                return new FileContentResult(user.Picture, "image/png");
            }            
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
