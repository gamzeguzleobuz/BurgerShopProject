namespace BurgerShopProject.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string MenuName { get; set; } = null!;
        public string MenuPrice { get; set; } = null!;

        public Size MenuSize { get; set; }

        public string? MenuImageName { get; set; }

        public List<Order> Orders { get; set; } = new();


    }
}
