using DotNetCoreSignalR.DotNetCoreSignalR.Business.Abstract;
using DotNetCoreSignalR.DotNetCoreSignalR.Business.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreSignalR.DotNetCoreSignalR.Business.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
        }
    }
}
