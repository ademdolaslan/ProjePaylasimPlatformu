using Microsoft.EntityFrameworkCore;
using ProjectSharing.DAL.DataContext;
using ProjectSharing.DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectSharing.DAL.Services
{
    public class PageService
    {
        private readonly ProjectSharingDbContext db = new ProjectSharingDbContext(ProjectSharingDbContext.ops.dbOptions);
        public List<Page> GetAllPages()
        {
            return db.Pages.Include(x=>x.Category).Include(x=>x.User).Where(x => x.IsVerified == true).ToList();
        }
        public Page GetPageByURL(string _pageURL)
        {
            return db.Pages.Include(x => x.Category).Include(x => x.User).FirstOrDefault(x => x.PageUrl == _pageURL);
        }
        public int AddNewPage(Page _page)
        {
            try
            {
                db.Pages.Add(_page);
                var affectedRow = db.SaveChanges();
                return affectedRow;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int UpdatePage(Page _page)
        {
            try
            {
                var updatedPage = db.Pages.FirstOrDefault(x => x.PageID == _page.PageID);
                updatedPage.PageTitle = _page.PageTitle;
                updatedPage.PageContent = _page.PageContent;
                updatedPage.PageTags = _page.PageTags;                
                var affectedRow = db.SaveChanges();
                return affectedRow;
            }
            catch (Exception)
            {
                return -1;
            }
            
        }
        public int DeletePage(int _pageId)
        {
            try
            {
                var deletedPage = db.Pages.FirstOrDefault(x => x.PageID == _pageId);
                deletedPage.IsVerified = false;
                var affectedRow = db.SaveChanges();
                return affectedRow;
            }
            catch (Exception)
            {
                return -1;
                
            }           
        }                
    }
}
