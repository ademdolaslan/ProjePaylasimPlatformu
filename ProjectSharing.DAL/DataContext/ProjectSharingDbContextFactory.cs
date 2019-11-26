using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ProjectSharing.DAL.DataContext
{
    public class ProjectSharingDbContextFactory : IDesignTimeDbContextFactory<ProjectSharingDbContext>
    {
        public ProjectSharingDbContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfig = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<ProjectSharingDbContext>();
            opsBuilder.UseSqlServer(appConfig.sqlConnectionString);
            return new ProjectSharingDbContext(opsBuilder.Options);
        }
    }
}
