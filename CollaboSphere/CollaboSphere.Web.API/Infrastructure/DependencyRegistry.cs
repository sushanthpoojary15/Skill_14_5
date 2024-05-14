using CollaboSphere.Business;
//using CollaboSphere.Business.Infrastructure;
using CollaboSphere.Common;
using CollaboSphere.Common.Model;
using CollaboSphere.DataAccess;
using CollaboSphere.DataAccess.Contracts;

namespace CollaboSphere.Web.API.Infrastructure
{
    public static class DependencyRegistry
    {
        public static void RegisterDependency(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(appSettings);
            services.AddScoped<ApplicationContext>();
           
            

            BusinessDependencyRegistry.RegisterDependency(services, appSettings);
        }
    }
}
