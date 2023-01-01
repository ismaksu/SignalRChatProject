using DotNetCoreSignalR.DotNetCoreSignalR.Business.Abstract;
using DotNetCoreSignalR.DotNetCoreSignalR.Data.Concrete;
using DotNetCoreSignalR.DotNetCoreSignalR.Entity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSignalR.Hubs
{
    public class UserHub : Hub<IUserHubMethods>
    {
        public static int TotalViews { get; set; } = 0;

        public static int TotalUsers { get; set; } = 0;

        public override Task OnConnectedAsync()
        {
            TotalUsers++;
            Clients.All.UpdateTotalUsers(TotalUsers).GetAwaiter().GetResult();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            TotalUsers--;
            Clients.All.UpdateTotalUsers(TotalUsers);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task UserJoined(string username)
        {
            User user = new User()
            {
                ConnectionId = Context.ConnectionId,
                Username = username
            };

            TableContext.Users.Add(user);

            TotalViews++;

            await Clients.All.ClientJoined(username, TotalViews);
            await Clients.All.UpdateClients(TableContext.Users);
        }

        public async Task SendMessage(string username, string message)
        {
            await Clients.Others.SendMessage(username, message);
        }
    }
}
