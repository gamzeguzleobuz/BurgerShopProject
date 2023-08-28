using Microsoft.AspNetCore.Identity;

namespace BurgerShopProject.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public DateTime MemberSince { get; set; } = DateTime.Now;


        //public List<Burger> Burgers { get; set; } = new();
        //public List<SideProduct> SideProducts { get; set; } = new();
        //public List<Beverages> Beverages { get; set; } = new();
        //public List<Sauce> Sauces { get; set; } = new();


        // buradaki kodlari gerekirse tekrardan ac

        public List<Order> Orders { get; set; } = new();

    }
}
