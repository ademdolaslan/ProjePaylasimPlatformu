using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectSharing.BLL.Models;
using ProjectSharing.DAL.Entities;
using ProjectSharing.DAL.Models;
using ProjectSharing.DAL.Services;

namespace ProjectSharing.BLL
{
    public class PageBLL
    {
        readonly PageService service = new PageService();
        public List<Page> GetAllPages()
        {
            var allPages = service.GetAllPages();
            if (allPages==null)
            {
                return null;
            }
            else
            {
                return allPages;
            }
        }
        public Page GetSinglePage(string _url)
        {
            var page = service.GetPageByURL(_url);
            if (page==null)
            {
                return null;
            }
            else
            {
                return page;
            }
        }
        public int UpdatePage(Page updatedPage)
        {
            if (updatedPage is null)
            {
                return 404;
            }
            else
            {                
                return service.UpdatePage(updatedPage);
            }
        }
        public int AddPage(Page addedPage)
        {
            if (addedPage is null)
            {
                return 404;
            }
            else
            {
                addedPage.PageUrl = addedPage.PageTitle.ToLower()
                    .Replace(' ', '-')
                    .Replace('ü', 'u')
                    .Replace('ç', 'c')                    
                    .Replace('ş', 's')
                    .Replace('ğ', 'g')
                    .Replace('ö', 'o')
                    .Replace('ı', 'i');
                addedPage.IsVerified = false;
                addedPage.PageViewCount = 0;
                return service.AddNewPage(addedPage);
            }
        }
        public int DeletePage(Page deletedPage)
        {
            if (deletedPage is null)
            {
                return 404;
            }
            else
            {
                return service.DeletePage(deletedPage.PageID);
            }
        }
        public List<PageCountByCategory> PageCountByCategories()
        {
            return service.PageCountByCategory();
        }
        public List<PageInfo> PagesWithFullDescription()
        {
            List<PageInfo> pages = new List<PageInfo>();
            var _pages =service.GetAllPages();
            var _users = new UserBLL().GetAllUsers();
            var _categories = new CategoryBLL().GetCategories();
            foreach (var item in _pages)
            {
                pages.Add(new PageInfo() {
                Page=item,
                Category=_categories.FirstOrDefault(x=>x.CategoryID==item.PageCategoryID),
                User=_users.FirstOrDefault(x=>x.UserID==item.UserID)      
                });
            }
            return pages;
            
        }
    }
}
