﻿using Microsoft.AspNetCore.Identity;

namespace BurgerShopProject.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public List<Order> Orders { get; set; } = new();

    }
}
