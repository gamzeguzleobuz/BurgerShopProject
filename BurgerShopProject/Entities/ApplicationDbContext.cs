using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurgerShopProject.Entities
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Menu> Menus => Set<Menu>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Extra> Extras => Set<Extra>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}