using DotNetCoreSignalR.DotNetCoreSignalR.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSignalR.DotNetCoreSignalR.Data.Concrete
{
    public class TableContext
    {
        public static List<User> Users { get; } = new List<User>();
    }
}
