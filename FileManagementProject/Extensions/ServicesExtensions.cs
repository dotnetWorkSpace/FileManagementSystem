using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;

namespace FileManagementProject.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
