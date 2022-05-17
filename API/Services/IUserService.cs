namespace API.Services
{
    public interface IUserService
    {
        public void AddUserSignalR(string username, string userId);
        public bool GetUserIdSignalR(string username, out string userId);
        public bool SignIn(string Username, string Password);
        public bool SignUp(string Username, string Name, string Password);
    }
}
