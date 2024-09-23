using System;
using Microsoft.AspNetCore.Identity;

namespace DKTech.Areas.Identity.Data
{
    // Custom user class inheriting from IdentityUser
    public class User : IdentityUser
    {
        // Property for the user's first name
        public string FirstName { get; set; }

        // Property for the user's last name
        public string LastName { get; set; }
    }
}
