using BurgerShopProject.Entities;
using System.ComponentModel.DataAnnotations;


namespace BurgerShopProject.Areas.Admin.Models
{
    public class MenuViewModel
    {
        [MaxLength(400)]
        public string MenuName { get; set; } = null!;
        public decimal MenuPrice { get; set; }

        public Size MenuSize { get; set; }

        public IFormFile MenuImageName { get; set; } = null!;
    }
}
