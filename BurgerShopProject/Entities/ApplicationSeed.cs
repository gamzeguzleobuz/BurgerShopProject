using Microsoft.AspNetCore.Identity;

namespace BurgerShopProject.Entities
{
    public class ApplicationSeed
    {
        public static async Task Seed(ApplicationDbContext db, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "admin@example.com";
            var adminPassword = "P@ssword1";
            var adminRoleName = "Admin";
            var customerRoleName = "Customer";
            var firstname = "Ali";
            var lastName = "Cabbar";

            if (userManager.Users.Any(x => x.UserName == adminEmail) || await roleManager.RoleExistsAsync(adminRoleName))
                return;

            var adminUser = new AppUser()
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                FirstName = firstname,
                LastName = lastName
            };

            await roleManager.CreateAsync(new IdentityRole(adminRoleName));
            await userManager.CreateAsync(adminUser, adminPassword);
            await userManager.AddToRoleAsync(adminUser, adminRoleName);

            await roleManager.CreateAsync(new IdentityRole(customerRoleName));

            await db.SaveChangesAsync();
        }
    }
}
