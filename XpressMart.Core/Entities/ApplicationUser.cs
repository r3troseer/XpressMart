using Microsoft.AspNetCore.Identity;

namespace XpressMart.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
