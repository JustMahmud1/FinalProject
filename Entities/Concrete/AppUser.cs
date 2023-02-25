using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace Entities.Concrete
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }

    }
}
