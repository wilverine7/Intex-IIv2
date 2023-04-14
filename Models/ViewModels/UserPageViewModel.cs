using System;
using Microsoft.AspNetCore.Identity;

namespace Mummies.Models.ViewModels
{
	public class UserPageViewModel
	{
        public List<IdentityUser> UsersInfo { get; set; }
        public List<IdentityRole> UserJoin { get; set; }

        public string UserRole { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
    }
}

