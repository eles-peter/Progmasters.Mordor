using Microsoft.Extensions.DependencyInjection;
using Progmasters.Mordor.ServicesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Services
{
    public static class RegisterDependencies    {
        public static void RegisterServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IOrcService, OrcService>();
        }

    }
}
