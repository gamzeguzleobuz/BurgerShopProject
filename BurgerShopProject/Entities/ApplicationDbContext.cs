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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Menu>().HasData(

                new Menu() { Id = 1, MenuName = "Big King", MenuPrice = 22m, MenuSize = Size.Small, MenuImageName = "bigKing.png" },
                new Menu() { Id = 2, MenuName = "Big Turkey", MenuPrice = 12m, MenuSize = Size.Small, MenuImageName = "bigChicken.png" },
                new Menu() { Id = 3, MenuName = "Double Whopper", MenuPrice = 34m, MenuSize = Size.Small, MenuImageName = "burger (1).png" },
                new Menu() { Id = 4, MenuName = "King Chicken", MenuPrice = 14m, MenuSize = Size.Small, MenuImageName = "burger (2).png" },
                new Menu() { Id = 5, MenuName = "Double Kofte Burger", MenuPrice = 42m, MenuSize = Size.Small, MenuImageName = "product-1.png" },
                new Menu() { Id = 6, MenuName = "Bacon Burger", MenuPrice = 20m, MenuSize = Size.Small, MenuImageName = "product-2.png" },
                new Menu() { Id = 7, MenuName = "Double King Vegan", MenuPrice = 10m, MenuSize = Size.Small, MenuImageName = "product-4.png" },
                new Menu() { Id = 8, MenuName = "Eggcellent Burger", MenuPrice = 18m, MenuSize = Size.Small, MenuImageName = "product-5.png" });


            modelBuilder.Entity<Extra>().HasData(
                  new Extra() { Id = 1, ExtraName = "Fries", ExtraPrice = 5m, ExtraImageName = "extra-1.png" },
                  new Extra() { Id = 2, ExtraName = "Onion Ring", ExtraPrice = 10m, ExtraImageName = "extra-3.png" },
                  new Extra() { Id = 3, ExtraName = "Cola", ExtraPrice = 15m, ExtraImageName = "extra-5.png" },
                  new Extra() { Id = 4, ExtraName = "Ice-Tea", ExtraPrice = 5m, ExtraImageName = "extra-7.png" },
                  new Extra() { Id = 5, ExtraName = "Curly Fries", ExtraPrice = 15m, ExtraImageName = "extra-2.png" },
                  new Extra() { Id = 6, ExtraName = "Honey Mustard", ExtraPrice = 15m, ExtraImageName = "extra-9.png" },
                  new Extra() { Id = 7, ExtraName = "Cola-Zero", ExtraPrice = 15m, ExtraImageName = "extra-6.png" }
              );

        }
    }
}