using BurgerShopProject.Enums;

namespace BurgerShopProject.Entities
{
    public class Order : Base
    {
        private readonly List<Burger> _burgers;
        private readonly List<SideProduct> _sideProducts;
        private readonly List<Beverages> _beverages;
        private readonly List<Sauce> _sauces;
        private readonly AppUser _appUser;


        public Order()
        {
            
        }

        public Order(List<Burger> burgers, List<SideProduct> sideProducts, List<Beverages> beverages, List<Sauce> sauces, AppUser appUser)
        {
            _burgers = burgers;
            _sideProducts = sideProducts;
            _beverages = beverages;
            _sauces = sauces;
            _appUser = appUser;
        }

        private decimal _totalPrice;

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = Calculate();}
        }



        public decimal Calculate()
        {
            decimal totalPrice = 0;

            foreach (var item in _burgers)
            {
                totalPrice += item.Price * item.Quantity;
            }

            foreach (var item in _sideProducts)
            {
                totalPrice += item.Price * item.Quantity;
            }

            foreach (var item in _beverages)
            {
                totalPrice += item.Price * item.Quantity;
            }

            foreach (var item in _sauces)
            {
                totalPrice += item.Price * item.Quantity;
            }


            return totalPrice;

        }

    }
}
