using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSharing.BLL;
using ProjectSharing.UI.Models;


namespace ProjectSharing.UI.Controllers
{
    [Authorize(Roles = "Admin,User,Editor")]
    public class ProjectController : Controller
    {

        public IActionResult Share()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SavePage(HtmlTextViewModel model)
        {
            var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var loggedUser = new UserBLL().GetUser(userEmail);
            PageBLL pageBLL = new PageBLL();
            var addedpageId = pageBLL.AddPage(new DAL.Entities.Page()
            {
                UserID = loggedUser.UserID,
                PageCategoryID = model.PageCategory,
                CreateDate = DateTime.Now,
                PageContent = model.HtmlText,
                PageDescription = model.PageDescription,
                PageTags = model.PageTags,
                PageTitle = model.PageTitle,
            });
            if (model.PageFiles != null)
            {
                MemoryStream ms = new MemoryStream();
                model.PageFiles.CopyTo(ms);
                var fileBytes = ms.ToArray();

                FileService.FileServiceClient f = new FileService.FileServiceClient();
                var fileGuidName = Guid.NewGuid();
                f.UploadToTempFolderAsync(fileBytes, fileGuidName.ToString());
                FileBLL fileBLL = new FileBLL();
                fileBLL.AddNewFile(new DAL.Entities.File()
                {
                    FileName = model.PageFiles.FileName,
                    FilePath = fileGuidName.ToString(),
                    FileSize = model.PageFiles.Length.ToString(),
                    FileType = model.PageFiles.FileName.Split('.')[1],
                    FileVersion="1",
                    PageID=addedpageId,
                    UserID=loggedUser.UserID
                });
            }
            return RedirectToAction("Index", "Home");

        }

        [AllowAnonymous]
        public IActionResult ViewPage(string id)
        {
            var page = new PageBLL().GetSinglePage(id);
            if (page==null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            var pageFile = new FileBLL().GetFilesbyPageID(page.PageID);
            var comments = new CommentBLL().GetAllComments(page.PageID);
            var model = new PageInfoViewModel() { 
            PageComments=comments,
            PageFiles=pageFile,
            PageInfo=page
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult AddSubCommentToPage(SubCommentViewModel m)
        {
            var url = new PageBLL().GetUrlByID(m.PageID);
            var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var loggedUser = new UserBLL().GetUser(userEmail);
            var result = new CommentBLL().AddSubComment(m.PageID, m.ParentCommentID, m.CommentTitle, m.CommentText, loggedUser.UserID);
            if (result == -1)
            {
                TempData["StatusMessage"] = "Yorum Eklenirken Bir Hata Oluştu.";
                TempData["StatusColor"] = "alert-danger";
                return RedirectToAction("ViewPage", "Project", new { id = url });
            }
            else if (result == 0)
            {

                TempData["StatusMessage"] = "Yorum Eklenemedi.";
                TempData["StatusColor"] = "alert-warning";
                return RedirectToAction("ViewPage", "Project", new { id = url });
                //yorum eklenemedi
            }
            else if (result == 1)
            {

                TempData["StatusMessage"] = "Yorum Eklendi.";
                TempData["StatusColor"] = "alert-success";
                return RedirectToAction("ViewPage", "Project", new { id = url });
                //yorum eklendi
            }
            else
            {
                TempData["StatusMessage"] = "Yorum Eklenirken Bir Hata Oluştu";
                TempData["StatusColor"] = "alert-danger";
                return RedirectToAction("ViewPage", "Project", new { id = url });
                //bilinmeyen bir hata
            }
        }
        [HttpPost]
        public RedirectToActionResult AddCommentToPage(CommentViewModel m)
        {
            var url = new PageBLL().GetUrlByID(m.PageID);
            var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            var loggedUser = new UserBLL().GetUser(userEmail);
            var result = new CommentBLL().AddComment(m.PageID, m.CommentTitle, m.CommentText, loggedUser.UserID);
            if (result == -1)
            {
                TempData["StatusMessage"] = "Yorum Eklenirken Bir Hata Oluştu.";
                TempData["StatusColor"] = "alert-danger";
                return RedirectToAction("ViewPage", "Project", new { id = url });
            }
            else if (result == 0)
            {

                TempData["StatusMessage"] = "Yorum Eklenemedi.";
                TempData["StatusColor"] = "alert-warning";
                return RedirectToAction("ViewPage", "Project", new { id = url });
                //yorum eklenemedi
            }
            else if (result == 1)
            {

                TempData["StatusMessage"] = "Yorum Eklendi.";
                TempData["StatusColor"] = "alert-success";
                return RedirectToAction("ViewPage", "Project", new { id = url });
                //yorum eklendi
            }
            else
            {
                TempData["StatusMessage"] = "Yorum Eklenirken Bir Hata Oluştu";
                TempData["StatusColor"] = "alert-danger";
                return RedirectToAction("ViewPage", "Project", new { id = url });
                //bilinmeyen bir hata
            }
        }
    }
}