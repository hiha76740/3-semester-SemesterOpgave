namespace UserService.ApplicationLib.Authentication;

public interface IPasswordHashService
{
    string Hash(string password);

    bool Verify(string password,string passwordHash);
}
