using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public class ShopWebContext : IdentityDbContext<ApplicationUser>
    {

        public ShopWebContext()
        {

        }

        public ShopWebContext(DbContextOptions<ShopWebContext> options)
          : base(options)
        {
        }


        public DbSet<Users> UsersTb { get; set; }
        public DbSet<Categories> CategoriesTb { get; set; }
        public DbSet<Items> ItemsTb { get; set; }
        public DbSet<TbSlider> TbSlider { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBulider)
        {
            base.OnModelCreating(modelBulider);
            modelBulider.Entity<Items>()
               .HasOne<Categories>(s => s.Categories)
               .WithMany(g => g.Items)
               .HasForeignKey(s => s.CategoryId);
        }
    }
}
