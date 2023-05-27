using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class CustomUser : IdentityUser
    {
        public string Fullname { get; set; }
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpireDate { get; set; }

    }
}
