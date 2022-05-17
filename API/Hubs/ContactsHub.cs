using API.Services;
using Microsoft.AspNetCore.SignalR;

namespace API.Hubs
{
    public class ContactsHub : Hub
    {
        private readonly IUserService _user;

        public ContactsHub (IUserService user)
        {
            _user = user;
        }

        public void Connect(string username)
        {
            _user.AddUserSignalR(username, Context.ConnectionId);
        }
         
        public async Task ContactChanged(int refresh, string username)
        {
            string userId;
            if(_user.GetUserIdSignalR(username, out userId))
            {
                await Clients.Client(userId).SendAsync("ChangeRecived", refresh + 1);
            }
        }
    }
}
