using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace I_9Form.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public enum UserStage
    {
        setup,
        use,
        block
    }

    public class ApplicationUser : IdentityUser
    {
        public int EmployeeID { get; set; }
        public UserStage userstage { get; set; }
    }
    //This class contains all extension related with Application User.
    public static class IdentityExtension
    {
        public static string getEmployeeID(this IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                ClaimsIdentity claimsIdentity = user.Identity as ClaimsIdentity;
                foreach (var claim in claimsIdentity.Claims)
                {
                    if (claim.Type == "EmployeeID")
                        return claim.Value;
                }
                return "";
            }
            else
                return "";
        }
        public static string GetUserID(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        }
    }
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public AppClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager
            , RoleManager<IdentityRole> roleManager
            , IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
        { }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            if (!string.IsNullOrWhiteSpace(user.EmployeeID.ToString()))
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
        new Claim("EmployeeID", user.EmployeeID.ToString())
    });
            }

            return principal;
        }
    }
}
