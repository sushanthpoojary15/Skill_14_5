using Microsoft.Extensions.DependencyInjection;
using CollaboSphere.Common;
using CollaboSphere.DataAccess;

namespace CollaboSphere.Business
{
    public static class BusinessDependencyRegistry
    {
        public static void RegisterDependency(this IServiceCollection services, AppSettings appSettings)
        {
            RepositoryDependencyRegistry.DependencyRegistry(services, appSettings);
            services.AddTransient<UserBusiness>();
            services.AddTransient<RoleAuthorizationFilter>();
            services.AddTransient<XyzBusiness>();
            services.AddTransient<ProjectBusiness>();
            
            services.AddTransient<RoleBusiness>();
            services.AddTransient<DocumentBusiness>();

            services.AddTransient<TaskBusiness>();
        }
    }
}