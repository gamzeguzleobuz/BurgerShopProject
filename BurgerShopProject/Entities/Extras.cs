namespace BurgerShopProject.Entities
{
    public class Extras
    {
        public int Id { get; set; }
        public string ExtraName { get; set; } = null!;

        public decimal ExtraPrice { get; set; }

        public List<Order> Orders { get; set; } = new();
    }
}
