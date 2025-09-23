using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaProject.Models;

namespace PizzaProject.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<HomeInfo> HomeInfos { get; set; }
        public DbSet<HomeService> HomeServices { get; set; }
        public DbSet<HomeGalery> HomeGaleries { get; set; }
        public DbSet<Chef> Chefs { get; set; }

    }
}
