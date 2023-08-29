using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace BurgerShopProject.Areas.Admin.Models
{
    public class MenuViewModel
    {
        [MaxLength(400)]
        public string MenuName { get; set; } = null!;
        public string MenuPrice { get; set; } = null!;

        public Size MenuSize { get; set; }

        public IFormFile? MenuImageName { get; set; }
    }
}
