﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectSharing.DAL.DataContext;

namespace ProjectSharing.DAL.Migrations
{
    [DbContext(typeof(ProjectSharingDbContext))]
    partial class ProjectSharingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectSharing.DAL.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryDescription");

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProjectSharing.DAL.Entities.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentParentID");

                    b.Property<string>("CommentText");

                    b.Property<string>("CommentTitle");

                    b.Property<bool>("IsVerified");

                    b.Property<int>("PageID");

                    b.Property<int>("Rating");

                    b.Property<string>("UserID");

                    b.HasKey("CommentID");

                    b.HasIndex("PageID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ProjectSharing.DAL.Entities.File", b =>
                {
                    b.Property<int>("FileID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName");

                    b.Property<string>("FilePath");

                    b.Property<string>("FileSize");

                    b.Property<string>("FileType");

                    b.Property<string>("FileVersion");

                    b.Property<int>("PageID");

                    b.Property<string>("UserID");

                    b.HasKey("FileID");

                    b.HasIndex("PageID");

                    b.HasIndex("UserID");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ProjectSharing.DAL.Entities.Page", b =>
                {
                    b.Property<int>("PageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsVerified");

                    b.Property<int>("PageCategoryID");

                    b.Property<string>("PageContent");

                    b.Property<string>("PageDescription");

                    b.Property<string>("PageTags");

                    b.Property<string>("PageTitle");

                    b.Property<string>("PageUrl");

                    b.Property<int>("PageViewCount");

                    b.Property<string>("UserID");

                    b.HasKey("PageID");

                    b.HasIndex("PageCategoryID");

                    b.HasIndex("PageUrl")
                        .IsUnique()
                        .HasFilter("[PageUrl] IS NOT NULL");

                    b.HasIndex("UserID");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("ProjectSharing.DAL.Entities.User", b =>
                {
                    b.Property<string>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("IsBanned");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<byte[]>("Picture");

                    b.Property<string>("Region");

                    b.Property<string>("Tel");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("UserType");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectSharing.DAL.Entities.Comment", b =>
                {
                    b.HasOne("ProjectSharing.DAL.Entities.Page", "Page")
                        .WithMany("Comment")
                        .HasForeignKey("PageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSharing.DAL.Entities.User", "User")
                        .WithMany("Comment")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("ProjectSharing.DAL.Entities.File", b =>
                {
                    b.HasOne("ProjectSharing.DAL.Entities.Page", "Page")
                        .WithMany("File")
                        .HasForeignKey("PageID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSharing.DAL.Entities.User", "User")
                        .WithMany("File")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("ProjectSharing.DAL.Entities.Page", b =>
                {
                    b.HasOne("ProjectSharing.DAL.Entities.Category", "Category")
                        .WithMany("Page")
                        .HasForeignKey("PageCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectSharing.DAL.Entities.User", "User")
                        .WithMany("Pages")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
