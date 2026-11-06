using System.Security.Claims;

namespace BookMyHome.BuildingBlocksLib.Helpers;

/// <summary>
/// 
/// </summary>
public static class UserHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static Guid? GetCurrentUserId(ClaimsPrincipal user)
    {
        var stringUserId = user.FindFirstValue(ClaimTypes.NameIdentifier);

        var idIsValid = Guid.TryParse(stringUserId, out var id);

        if (idIsValid == false)
            return null;

        return id;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public static bool IsValidRole(ClaimsPrincipal user, string role)
    {
        if (user.FindFirstValue(ClaimTypes.Role) == role)
            return true;

        return false;
    }
}
