using DotNetCoreSignalR.DotNetCoreSignalR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSignalR.DotNetCoreSignalR.Business.Abstract
{
    public interface IUserService
    {
        void AddUser(User user);
        List<User> GetUserList();
        void DeleteUser(string connectionId);
    }
}
