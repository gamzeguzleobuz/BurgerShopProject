using System.Drawing;

namespace BurgerShopProject.Entities
{
    public class Beverages : Base
    {
        public Size Size { get; set; }
        public List<AppUser> AppUsers { get; set; } = new();
    }
}
