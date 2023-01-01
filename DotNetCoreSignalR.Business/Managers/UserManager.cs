using DotNetCoreSignalR.DotNetCoreSignalR.Business.Abstract;
using DotNetCoreSignalR.DotNetCoreSignalR.Data.Concrete;
using DotNetCoreSignalR.DotNetCoreSignalR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSignalR.DotNetCoreSignalR.Business.Managers
{
    public class UserManager : IUserService
    {
        public void AddUser(User user)
        {
            TableContext.Users.Add(user);
        }

        public void DeleteUser(string connectionId)
        {
            var user = TableContext.Users.Where(x => x.ConnectionId == connectionId).FirstOrDefault();
            TableContext.Users.Remove(user);
        }

        public List<User> GetUserList()
        {
            return TableContext.Users;
        }
    }
}
