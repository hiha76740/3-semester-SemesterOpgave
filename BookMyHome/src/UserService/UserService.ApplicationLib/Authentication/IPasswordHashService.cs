namespace UserService.ApplicationLib.Authentication;

/// <summary>
/// 
/// </summary>
public interface IPasswordHashService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    string Hash(string password);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="password"></param>
    /// <param name="passwordHash"></param>
    /// <returns></returns>
    bool Verify(string password, string passwordHash);
}
