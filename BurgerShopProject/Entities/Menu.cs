namespace BurgerShopProject.Entities
{
    public class Menu : Base
    {
        private readonly List<Burger> _burgers;
        private readonly List<SideProduct> _sideProducts;
        private readonly List<Beverages> _beverages;
        private readonly List<Sauce> _sauces;
        public Menu(List<Burger> burgers, List<SideProduct> sideProducts, List<Beverages> beverages, List<Sauce> sauces)
        {
            _burgers = burgers;
            _sideProducts = sideProducts;
            _beverages = beverages;
            _sauces = sauces;
        }





    }
}
