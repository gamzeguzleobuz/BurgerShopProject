namespace BurgerShopProject.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
