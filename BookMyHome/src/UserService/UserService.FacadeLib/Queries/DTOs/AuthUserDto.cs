namespace UserService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Username"></param>
/// <param name="Firstname"></param>
/// <param name="Lastname"></param>
/// <param name="Role"></param>
public record AuthUserDto(Guid Id, string Username, string Firstname, string Lastname, string Role);
