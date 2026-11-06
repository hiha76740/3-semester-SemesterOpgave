namespace UserService.ApplicationLib.Authentication;

/// <summary>
/// 
/// </summary>
public interface IRefreshTokenService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    string GenerateRefreshToken();
}
