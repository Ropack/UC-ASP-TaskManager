﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UC.ASP.TaskManager.DAL;

namespace UC.ASP.TaskManager.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UC.ASP.TaskManager.DAL.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("UC.ASP.TaskManager.DAL.Entities.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<int>("ProductId");

                    b.Property<bool>("Resolved");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("UC.ASP.TaskManager.DAL.Entities.IssueComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("IssueId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.ToTable("IssueComments");
                });

            modelBuilder.Entity("UC.ASP.TaskManager.DAL.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("UC.ASP.TaskManager.DAL.Entities.Issue", b =>
                {
                    b.HasOne("UC.ASP.TaskManager.DAL.Entities.Product", "Product")
                        .WithMany("Issues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UC.ASP.TaskManager.DAL.Entities.IssueComment", b =>
                {
                    b.HasOne("UC.ASP.TaskManager.DAL.Entities.Issue", "Issue")
                        .WithMany("IssueComments")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UC.ASP.TaskManager.DAL.Entities.Product", b =>
                {
                    b.HasOne("UC.ASP.TaskManager.DAL.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
