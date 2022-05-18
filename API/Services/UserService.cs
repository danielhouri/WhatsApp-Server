using API.Data;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly APIContext _context;
        public UserService(APIContext Context)
        {
            _context = Context;
        }

        public bool SignIn(string Username, string Password)
        {
            var res = _context.User.SingleOrDefault(u => u.Username == Username && u.Password == Password);
            if (res != null)
            {
                return true;
            }
            return false;
        }

        public bool SignUp(string Username, string Name, string Password)
        {
            var res = _context.User.SingleOrDefault(u => u.Username == Username);
            if (res == null)
            {
                var user = new User() { Username = Username, Password = Password, Name = Name, Contacts = new List<Contact>() };
                _context.User.Add(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
