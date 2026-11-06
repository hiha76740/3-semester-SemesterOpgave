namespace BookMyHome.ContractsLib.Requests.Users;

/// <summary>
/// 
/// </summary>
/// <param name="Username"></param>
/// <param name="Password"></param>
public record LoginRequest(
    string Username,
    string Password
    );
