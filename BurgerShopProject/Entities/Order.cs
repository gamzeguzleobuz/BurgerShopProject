namespace BurgerShopProject.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public List<Menu> Menus { get; set; } = new();
        public AppUser Customer { get; set; } = null!;

        public List<Extras> Extras { get; set; } = new();

        public int OrderPiece { get; set; }

        public decimal OrderPrice { get; set; }
    }
}
