﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectSharing.DAL.DataContext;

namespace ProjectSharing.DAL.Migrations
{
    [DbContext(typeof(ProjectSharingDbContext))]
    [Migration("20191126083355_PagesTable")]
    partial class PagesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectSharing.DAL.Entities.Page", b =>
                {
                    b.Property<int>("PageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsVerified");

                    b.Property<string>("PageContent");

                    b.Property<string>("PageTags");

                    b.Property<string>("PageTitle");

                    b.Property<string>("PageUrl");

                    b.Property<int>("PageViewCount");

                    b.Property<string>("UserID");

                    b.HasKey("PageID");

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

            modelBuilder.Entity("ProjectSharing.DAL.Entities.Page", b =>
                {
                    b.HasOne("ProjectSharing.DAL.Entities.User", "User")
                        .WithMany("Pages")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
