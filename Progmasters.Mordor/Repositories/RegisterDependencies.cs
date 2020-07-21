using Microsoft.Extensions.DependencyInjection;
using Progmasters.Mordor.RepositoriesAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progmasters.Mordor.Repositories
{
    public static class RegisterDependencies
    {
        public static void RegisterRepositoryDependencies(this IServiceCollection services)
        {
            services.AddTransient<IOrcRepository, OrcRepository>();
        }
    }
}
