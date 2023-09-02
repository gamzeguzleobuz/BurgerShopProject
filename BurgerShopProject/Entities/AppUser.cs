using Microsoft.AspNetCore.Identity;

namespace BurgerShopProject.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public List<Order> Orders { get; set; } = new();

    }
}
