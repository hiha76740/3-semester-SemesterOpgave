namespace EmailService.ApplicationLib.Dtos;

/// <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <param name="Email"></param>
/// <param name="Subject"></param>
/// <param name="Body"></param>
public record SendEmailDto(string Name, string Email, string Subject, string Body);
