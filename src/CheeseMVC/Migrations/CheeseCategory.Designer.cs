using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CheeseMVC.Data;

namespace CheeseMVC.Migrations
{
    [DbContext(typeof(CheeseDBContext))]
    [Migration("20170406122516_CheeseCategory")]
    partial class CheeseCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CheeseMVC.Models.Cheese", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int?>("CategoryID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Odor");

                    b.Property<int>("Rating");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Cheeses");
                });

            modelBuilder.Entity("CheeseMVC.Models.CheeseCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CheeseMVC.Models.Cheese", b =>
                {
                    b.HasOne("CheeseMVC.Models.CheeseCategory", "Category")
                        .WithMany("Cheeses")
                        .HasForeignKey("CategoryID");
                });
        }
    }
}
