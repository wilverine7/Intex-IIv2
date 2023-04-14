using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Mummies.Data;

namespace Mummies.Data
{
    public class AdminSeed
    {
        public static async Task Initialize(ApplicationDbContext context,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            string asdminRole = "Admin";
            string memberRole = "Member";
            string password4all = "Intex2023admin";
            if (await roleManager.FindByNameAsync(asdminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(asdminRole));
            }
            if (await roleManager.FindByNameAsync(memberRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(memberRole));
            }
            if (await userManager.FindByNameAsync("admin@admin.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    PhoneNumber = "6902341234",
                    EmailConfirmed = true
                    
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password4all);
                    await userManager.AddToRoleAsync(user, asdminRole);
                }
            }
            if (await userManager.FindByNameAsync("mm@mm.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "mm@mm.mm",
                    Email = "mm@mm.mm",
                    PhoneNumber = "1112223333",
                    EmailConfirmed = true

                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password4all);
                    await userManager.AddToRoleAsync(user, memberRole);
                }
            }
        }
    }
}

