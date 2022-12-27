using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSignalR.DotNetCoreSignalR.Business.Abstract
{
    public interface IUserHubMethods
    {
        Task UpdateTotalUsers(int totalUsers);
        Task UpdateTotalViews(int totalViews);
        Task SendMessage(string username, string message);
    }
}
