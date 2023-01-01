using DotNetCoreSignalR.DotNetCoreSignalR.Data.Concrete;
using DotNetCoreSignalR.DotNetCoreSignalR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSignalR.DotNetCoreSignalR.Business.Abstract
{
    public interface IUserHubMethods
    {
        Task UpdateTotalUsers(int totalUsers);
        Task ClientJoined(string username, int totalViews);
        Task UpdateClients(List<User> users);
        Task SendMessage(string username, string message);
    }
}
