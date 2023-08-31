namespace BurgerShopProject.Areas.Admin.Models
{
    public class ExtraViewModel
    {
       
        public string ExtraName { get; set; } = null!;

        public decimal ExtraPrice { get; set; }

        public IFormFile ExtraImageName { get; set; } = null!;
    }
}
