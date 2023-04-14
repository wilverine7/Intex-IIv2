using System;
using Microsoft.AspNetCore.Identity;

namespace Mummies.Models.Users
{
    public class ListModel
    {
        public UserManager<IdentityUser> UserManager;
        public ListModel(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }
        public IEnumerable<IdentityUser> Users { get; set; }
        public void OnGet()
        {
            Users = UserManager.Users;
        }
    }
}

