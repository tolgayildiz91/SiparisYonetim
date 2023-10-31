using Microsoft.Extensions.DependencyInjection;
using SiparisYonetim.Domain.IRepositories;
using SiparisYonetim.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Infrastructure
{
    public static class AddInfrastructureRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();

        }
    }
}
