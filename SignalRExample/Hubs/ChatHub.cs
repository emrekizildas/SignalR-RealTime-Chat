using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRExample.Models;

namespace SignalRExample.Hubs
{
    public class ChatHub: Hub
    {
        readonly ApplicationDbContext _dbContext;
        public ChatHub(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SendMessage(string user, string message)
        {
            Message messageObject = new Message()
            {
                Username = user,
                MessageText = message,
                MesssageDate = DateTime.Now
            };
            _dbContext.Messages.Add(messageObject);
            await _dbContext.SaveChangesAsync();
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}