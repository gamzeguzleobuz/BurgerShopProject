using System.ComponentModel.DataAnnotations;

namespace BurgerShopProject.Entities
{
    public class Extra
    {
        public int Id { get; set; }

        [Display(Name = "Extra Name")]
        public string ExtraName { get; set; } = null!;

        [Display(Name = "Extra Price")]
        public decimal ExtraPrice { get; set; }

        [Display(Name = "Extra Image")]
        [Required(ErrorMessage = "Please upload an image file for the product.")]
        public string ExtraImageName { get; set; } = null!;

        public int Quantity { get; set; } = 1;

        public List<Order> Orders { get; set; } = new();
    }
}
