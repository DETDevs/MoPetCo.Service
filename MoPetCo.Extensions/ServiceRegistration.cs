using Microsoft.Extensions.DependencyInjection;
using MoPetCo.DataAccess;
using MoPetCo.DataAccess.Interfaces;

namespace MoPetCo.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddMoPetCoServices(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionManager, ConnectionManager>();
            services.AddScoped<IServicio, Servicio>();
            services.AddScoped<BusinessLogic.Interfaces.IServicio, BusinessLogic.Servicio>();
            services.AddScoped<IContacto, Contacto>();
            services.AddScoped<BusinessLogic.Interfaces.IContacto, BusinessLogic.Contacto>();
            services.AddScoped<BusinessLogic.EmailService>();
        }
    }
}
