using ProjectSharing.BLL.Models;
using ProjectSharing.DAL.Entities;

using ProjectSharing.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectSharing.BLL
{
    public class CategoryBLL
    {
        private readonly CategoryService service = new CategoryService();
        public List<Category> GetCategories()
        {
            return service.GetCategories();
        }
        public List<PageCountByCategory> PagesCountByCategory()
        {
            List<PageCountByCategory> list = new List<PageCountByCategory>();
            var pages = new PageBLL().GetAllPages();
            var categories = service.GetCategories();
            foreach (var category in categories)
            {
                list.Add(new PageCountByCategory()
                {
                    Category = category,
                    Count = pages.Count(x => x.PageCategoryID == category.CategoryID)
                });
            }
            return list;
        }
    }
}
