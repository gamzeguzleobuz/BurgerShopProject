using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurgerShopProject.Entities
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Menu> Menus => Set<Menu>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Extras> Extras => Set<Extras>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}