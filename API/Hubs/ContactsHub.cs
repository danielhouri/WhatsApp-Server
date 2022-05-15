using Microsoft.AspNetCore.SignalR;

namespace API.Hubs
{
    public class ContactsHub : Hub
    {
        public async Task ContactChanged(string value)
        {
            await Clients.All.SendAsync("ChangeRecived", value);
        }
    }
}
