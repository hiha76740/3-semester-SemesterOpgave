using System.Security.Claims;

namespace BookMyHome.BuildingBlocksLib.Helpers;

public static class UserHelper
{
    public static Guid? GetCurrentUserId(ClaimsPrincipal user)
    {
        var stringUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);

        var idIsValid = Guid.TryParse(stringUserId, out Guid id);

        if (idIsValid == false)
            return null;

        return id;
    }

    public static bool IsValidRole(ClaimsPrincipal user, string role)
    {
        if (user.FindFirstValue(ClaimTypes.Role) == role)
            return true;

        return false;
    }
}
