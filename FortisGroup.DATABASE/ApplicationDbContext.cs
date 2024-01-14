using FortisGroup.MODELS.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortisGroup.DATABASE
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> CategoryTB { get; set; }
        public DbSet<Item> ItemTB { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connectionString = @"Server=DESKTOP-CR30BFH\SQLEXPRESS; Database=Fortis_Group_DB; Trusted_Connection=True; TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);


        }
    }
}
