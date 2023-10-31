using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SiparisYonetim.Application.Services.AdminService;
using SiparisYonetim.Application.Services.ManagerService;
using SiparisYonetim.Application.Services.UserService;
using SiparisYonetim.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application
{
    public static class ApplicationServiceRegistration
    {

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
            services.AddAutoMapper(typeof(ApplicationServiceRegistration));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



            services.AddScoped<IUserService,UserManager>();
            services.AddScoped<IAdminService,AdminManager>();
            services.AddScoped<IManagerService, ManagerManager>();
           






        }




        public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
            {
                if (addWithLifeCycle == null)
                {
                    services.AddScoped(item);
                }
                else
                {
                    addWithLifeCycle(services, type);
                }
            }
            return services;
        }
    }
}
