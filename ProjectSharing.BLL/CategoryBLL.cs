using ProjectSharing.DAL.Entities;
using ProjectSharing.DAL.Models;
using ProjectSharing.DAL.Services;
using System;
using System.Collections.Generic;
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
        public List<PageCountByCategory> PageCountByCategory()
        {
            return new PageService().PageCountByCategory();
        }
    }
}
