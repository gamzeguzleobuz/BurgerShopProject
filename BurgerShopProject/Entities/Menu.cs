using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BurgerShopProject.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        [Display(Name = "Menu Name")]
        public string MenuName { get; set; } = null!;

        [Display(Name = "Menu Price")]
        public decimal MenuPrice { get; set; }

        [Display(Name = "Menu Size")]
        public Size MenuSize { get; set; }

        [Display(Name = "Menu Image")]
        [Required(ErrorMessage = "Please upload an image file for the product.")]
        public string MenuImageName { get; set; } = null!;

        public int Quantity { get; set; }


        public List<Order> Orders { get; set; } = new();


    }
}
