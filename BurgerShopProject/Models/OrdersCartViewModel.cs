using BurgerShopProject.Entities;

namespace BurgerShopProject.Models
{
    public class OrdersCartViewModel
    {
        public int Id { get; set; }
        public AppUser Customer { get; set; } = null!;
        public List<Menu>? Menus { get; set; } = new();
        public List<Extra>? Extras { get; set; } = new();
    }
}
