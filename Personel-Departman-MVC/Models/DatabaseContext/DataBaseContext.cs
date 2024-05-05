using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Personel_Departman_MVC.Models.Entity;

namespace Personel_Departman_MVC.Models.DatabaseContext
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Departman> Departmans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection String
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=DepartmanMVC;Integrated Security=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Relation Type!
            modelBuilder.Entity<Personel>()
                .HasOne(x => x._departman)
                .WithMany(x => x._personels);



            //Seed Datas!

            modelBuilder.Entity<Personel>().HasData(
                new Personel
                { Id = 1,
                  Name="Dogan", 
                  lName="Yildirim",
                  Email = "dgn@test.com",
                  Password = "123*",
                  ConfirmPassword = "123*",
                  DepartmanId = 1,

                },

                new Personel
                { Id = 2,
                  Name="Dogan", 
                  lName="Yildirim",
                  Email = "dgn@test.com",
                  Password = "123456",
                  ConfirmPassword = "dgn@test.com",
                  DepartmanId = 1
                }
                );


            modelBuilder.Entity<Departman>().HasData(
                new Departman
                {
                    Id = 1,
                    DepartmanName = "Marketing",
                    DepartmanDescription = "Marketing Departman"
                },

                new Departman
                {
                    Id = 2,
                    DepartmanName = "Finance",
                    DepartmanDescription = "Finance Departman"
                }

                );
        }
    }
}
