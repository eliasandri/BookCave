using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BookCave.Data
{
    public static class Initializer
    {
        public static async Task initial(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var users = new IdentityRole("Admin");
                await roleManager.CreateAsync(users);
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                var users = new IdentityRole("User");
                await roleManager.CreateAsync(users);
            }

            if (!await roleManager.RoleExistsAsync("Manager"))
            {
                var users = new IdentityRole("Manager");
                await roleManager.CreateAsync(users);
            }
        }
    }
}