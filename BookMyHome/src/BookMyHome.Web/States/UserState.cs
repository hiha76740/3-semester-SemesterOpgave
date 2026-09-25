namespace BookMyHome.Web.States
{
    public class UserState
    {
        public event Action? OnChange;

        public Guid? UserId { get; private set; }
        public string? Username { get; private set; }
        public string? Firstname { get; private set; }
        public string? Lastname { get; private set; }
        public string? Role { get; private set; }

        public void SetUser(Guid id, string firstname, string lastname,
            string username, string role)
        {
            UserId = id;
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Role = role;
            OnChange?.Invoke();
        }
    }
}
