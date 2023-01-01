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
        private readonly IUserService _userService;

        public UserHub(IUserService userService)
        {
            _userService = userService;
        }

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
            var connectionId = Context.ConnectionId;

            _userService.DeleteUser(connectionId);

            TotalUsers--;
            Clients.All.UpdateTotalUsers(TotalUsers);
            Clients.All.UpdateClients(_userService.GetUserList());
            return base.OnDisconnectedAsync(exception);
        }

        public async Task UserJoined(string username)
        {
            User user = new User()
            {
                ConnectionId = Context.ConnectionId,
                Username = username
            };

            _userService.AddUser(user);

            TotalViews++;

            await Clients.All.ClientJoined(username, TotalViews);
            await Clients.All.UpdateClients(_userService.GetUserList());
        }

        public async Task SendMessage(string username, string message)
        {
            await Clients.Others.SendMessage(username, message);
        }
    }
}
