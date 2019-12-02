using ProjectSharing.DAL.DataContext;
using ProjectSharing.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectSharing.DAL.Services
{
    public class CategoryService
    {
        private readonly ProjectSharingDbContext db = new ProjectSharingDbContext(ProjectSharingDbContext.ops.dbOptions);
        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }
    }
}
