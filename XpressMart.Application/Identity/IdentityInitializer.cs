using Microsoft.AspNetCore.Identity;

namespace XpressMart.Application.Identity
{
    public class IdentityInitializer
    {
        public static async Task InitializeAsync(RoleManager<IdentityRole> roleManager)
        {
            string adminRoleName = "Admin";

            if (!await roleManager.RoleExistsAsync(adminRoleName))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRoleName));
            }

        }
    }
}
