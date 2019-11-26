using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using ProjectSharing.DAL.Entities;

namespace ProjectSharing.DAL.DataContext
{
    public class ProjectSharingDbContext:DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<ProjectSharingDbContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }
            public DbContextOptionsBuilder<ProjectSharingDbContext> opsBuilder { get; set; }
            public DbContextOptions<ProjectSharingDbContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }

        }
        public static OptionsBuild ops = new OptionsBuild();
        public ProjectSharingDbContext(DbContextOptions<ProjectSharingDbContext> options) : base(options)
        {

        }
        //dbsetler buraya gelecek
        public DbSet<User> Users { get; set; }
    }
}
