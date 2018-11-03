using Camp.Data.Entity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;

namespace Camp.Web.Extensions
{
    public static class UserManagerExtensions
    {
        public static string GetUserFirstname(this UserManager<User> um, System.Security.Claims.ClaimsPrincipal User)
        {
            return um?.Users?.FirstOrDefault(x => x.UserName == User.Identity.Name).Firstname;
        }
    }

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal) =>
            principal.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
