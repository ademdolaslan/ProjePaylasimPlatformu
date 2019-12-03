using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectSharing.BLL;
using ProjectSharing.DAL.Entities;
using ProjectSharing.UI.Models;
using System.IO;

namespace ProjectSharing.UI.Controllers
{
    public class AccountController : Controller
    {
        UserBLL userService = new UserBLL();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLogin U)
        {
            if (!ModelState.IsValid)
            {
                return View(U);
            }
            else
            {
                ClaimsIdentity identity = null;
                var loggedUser = userService.GetUser(U.Username, U.Password);
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Email, loggedUser.Email),
                    new Claim(ClaimTypes.Name,loggedUser.FirstName+" "+loggedUser.LastName),
                    new Claim(ClaimTypes.UserData,JsonConvert.SerializeObject(U)),
                    new Claim(ClaimTypes.Role, loggedUser.UserType)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }

        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserRegister model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var memoryStream = new MemoryStream();
                model.Picture.CopyTo(memoryStream);
                var _picture = memoryStream.ToArray();
                var response = userService.AddUser(new User()
                {
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Password = model.Password,
                    Region = model.Region,
                    Tel = model.Tel,
                    UserName = model.UserName,
                    Picture = _picture
                });
                if (response == -1)
                {
                    //user eklenirken bir hata oluştu
                    return View(model);
                }
                else if (response == 0)
                {
                    //user eklenemedi
                    return View(model);
                }
                else if (response == 1)
                {
                    //user eklendi
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //nesne null
                    return View(model);
                }
            }
        }
    }
}