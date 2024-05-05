﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Personel_Departman_MVC.Models.DatabaseContext;

#nullable disable

namespace Personel_Departman_MVC.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240505131439_Initialize")]
    partial class Initialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Personel_Departman_MVC.Models.Entity.Departman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DepartmanDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmanName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departmans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmanDescription = "Marketing Departman",
                            DepartmanName = "Marketing"
                        },
                        new
                        {
                            Id = 2,
                            DepartmanDescription = "Finance Departman",
                            DepartmanName = "Finance"
                        });
                });

            modelBuilder.Entity("Personel_Departman_MVC.Models.Entity.Personel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmanId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmanId");

                    b.ToTable("Personels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConfirmPassword = "123*",
                            DepartmanId = 1,
                            Email = "dgn@test.com",
                            Name = "Dogan",
                            Password = "123*",
                            lName = "Yildirim"
                        },
                        new
                        {
                            Id = 2,
                            ConfirmPassword = "dgn@test.com",
                            DepartmanId = 1,
                            Email = "dgn@test.com",
                            Name = "Dogan",
                            Password = "123456",
                            lName = "Yildirim"
                        });
                });

            modelBuilder.Entity("Personel_Departman_MVC.Models.Entity.Personel", b =>
                {
                    b.HasOne("Personel_Departman_MVC.Models.Entity.Departman", "_departman")
                        .WithMany("_personels")
                        .HasForeignKey("DepartmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("_departman");
                });

            modelBuilder.Entity("Personel_Departman_MVC.Models.Entity.Departman", b =>
                {
                    b.Navigation("_personels");
                });
#pragma warning restore 612, 618
        }
    }
}
