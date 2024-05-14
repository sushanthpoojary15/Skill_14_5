using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CollaboSphere.Common;
using CollaboSphere.DataAccess.Contracts;
using CollaboSphere.DataAccess.Entities;

namespace CollaboSphere.DataAccess
{
    public static class RepositoryDependencyRegistry
    {
        public static void DependencyRegistry(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<CollaboSphereContext>(options =>
            {
                options.UseSqlServer(appSettings.DbConnectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IXyzRepository, XyzRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IRoleRepository,  RoleRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
        }
    }
}