using Estimation.Data.Repostitories;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using Estimation.Domain.Repostitories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Estimation.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IEstimationProjectRepository, EstimationProjectRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddEntityFrameworkNpgsql().

                 AddDbContext<RepositoryContext>(
                 opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
              );

            return services;
        }
    }
}
